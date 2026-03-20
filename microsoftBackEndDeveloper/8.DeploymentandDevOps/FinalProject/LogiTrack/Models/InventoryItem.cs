// Classe que representa um item de inventário no sistema LogiTrack
using System;
using System.ComponentModel.DataAnnotations;

namespace LogiTrack.Models
{
    public class InventoryItem
    {
        // Identificador único do item de inventário
        [Key]
        public int ItemId { get; set; }

        // Nome do item (obrigatório)
        [Required]
        public string Name { get; set; }

        // Quantidade disponível do item
        public int Quantity { get; set; }

        // Localização onde o item está armazenado
        public string Location { get; set; }

        // Chave estrangeira para o pedido (opcional, pois um item pode não estar em nenhum pedido)
        public int? OrderId { get; set; }

        // Referência de navegação para o pedido associado
        public virtual Order? Order { get; set; }

        // Método para exibir informações do item no console
        public void DisplayInfo()
        {
            Console.WriteLine($"Item: {Name} | Quantity: {Quantity} | Location: {Location}");
        }
    }
}