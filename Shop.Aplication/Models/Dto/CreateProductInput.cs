﻿namespace Shop.Aplication.Models.Dto
{
    public class CreateProductInput
    {
        public int Id { get; internal set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int quantity { get; set; }
    }
}
