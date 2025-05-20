﻿namespace Ambev.DeveloperEvaluation.Application.Dtos;

public class SaleItemResponseDto
{
    /// <summary>
    /// Gets or sets the saleItem.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the product associated with this sale itemItem.
    /// </summary>
    public ProductDto Product { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product sold.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the discount applied to the product.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Gets or sets the total amount for this sale item.
    /// </summary>
    public decimal TotalAmount => (UnitPrice * Quantity) - Discount;
}