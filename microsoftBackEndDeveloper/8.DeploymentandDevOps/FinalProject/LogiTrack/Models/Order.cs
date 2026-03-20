// Classe que representa um pedido no sistema LogiTrack
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LogiTrack.Models
{
    public class Order
    {
        // Identificador único do pedido
        [Key]
        public int OrderId { get; set; }

        // Nome do cliente que fez o pedido (obrigatório)
        [Required]
        public string CustomerName { get; set; }

        // Data em que o pedido foi realizado
        public DateTime DatePlaced { get; set; }

        // Lista de itens incluídos no pedido
        public virtual ICollection<InventoryItem> Items { get; set; } = new List<InventoryItem>();

        // Identificador do usuário que criou o pedido (para isolamento de dados)
        public string UserId { get; set; }

        // Referência de navegação para o usuário proprietário do pedido
        public virtual ApplicationUser User { get; set; }

        // Método para adicionar um item ao pedido
        public void AddItem(InventoryItem item)
        {
            // Verifica se o item já não está no pedido para evitar duplicatas
            if (!Items.Contains(item))
            {
                Items.Add(item);
                // Define o ID do pedido no item para manter a relação
                item.OrderId = OrderId;
                item.Order = this;
            }
        }

        // Método para remover um item do pedido
        public void RemoveItem(int itemId)
        {
            // Encontra o item pelo ID
            var item = Items.FirstOrDefault(i => i.ItemId == itemId);
            if (item != null)
            {
                Items.Remove(item);
                // Remove a referência do pedido no item
                item.OrderId = null;
                item.Order = null;
            }
        }

        // Método para gerar um resumo do pedido
        public string GetOrderSummary()
        {
            return $"Order #{OrderId} for {CustomerName} | Items: {Items.Count} | Placed: {DatePlaced.ToShortDateString()}";
        }
    }
}