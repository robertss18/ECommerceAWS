using E_CommerceApp.AppDbContext;
using E_CommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: /Cart/Add/5
        [HttpPost]
        public async Task<IActionResult> Add(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            // Check if product already in cart (OrderId null = "active cart")
            var existingCartItem = await _context.CartItems
                .FirstOrDefaultAsync(c => c.ProductId == productId && c.OrderId == null);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += 1;
                _context.CartItems.Update(existingCartItem);
            }
            else
            {
                var cartItem = new CartItem
                {
                    ProductId = productId,
                    Quantity = 1,
                    OrderId = null // not yet checked out
                };

                _context.CartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();

            // Calcular el total de unidades en el carrito activo
            var totalItems = await _context.CartItems
                .Where(c => c.OrderId == null)
                .SumAsync(c => c.Quantity);

            // Guardar el total en sesión
            HttpContext.Session.SetInt32("CartItemCount", totalItems);

            return RedirectToAction("Index", "Products");
        }


        // GET: /Cart
        public async Task<IActionResult> Index()
        {
            var cartItems = await _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.OrderId == null)
                .ToListAsync();

            return View(cartItems);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null || cartItem.OrderId != null) // Only delete if not part of an order
            {
                return NotFound();
            }

            // Obtener la cantidad que se va a eliminar para ajustar el contador
            int quantityToRemove = cartItem.Quantity;

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

            // Actualizar la sesión restando la cantidad eliminada
            int currentCount = HttpContext.Session.GetInt32("CartItemCount") ?? 0;
            int newCount = currentCount - quantityToRemove;
            if (newCount < 0) newCount = 0; // evitar negativos
            HttpContext.Session.SetInt32("CartItemCount", newCount);

            return RedirectToAction(nameof(Index));
        }

    }
}
