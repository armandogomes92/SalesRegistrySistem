using System;
using Xunit;
using FluentAssertions;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Unit.Tests.Sales
{
    public class SaleItemDiscountTests
    {
        [Theory]
        [InlineData(1, 100, 0)] // Menor que 4, sem desconto
        [InlineData(3, 50, 0)]  // Menor que 4, sem desconto
        public void ApplyDiscount_DeveNaoAplicarDesconto_QuandoQuantidadeMenorQue4(int quantidade, decimal precoUnitario, decimal descontoEsperado)
        {
            var item = new SaleItem { Quantity = quantidade, UnitPrice = precoUnitario };
            item.ApplyDiscount();
            item.Discount.Should().Be(descontoEsperado);
        }

        [Theory]
        [InlineData(4, 10, 4)]   // 10% de desconto
        [InlineData(9, 20, 18)]  // 10% de desconto
        public void ApplyDiscount_DeveAplicar10Porcento_QuandoQuantidadeEntre4e9(int quantidade, decimal precoUnitario, decimal descontoEsperado)
        {
            var item = new SaleItem { Quantity = quantidade, UnitPrice = precoUnitario };
            item.ApplyDiscount();
            item.Discount.Should().Be(descontoEsperado);
        }

        [Theory]
        [InlineData(10, 10, 20)]  // 20% de desconto
        [InlineData(15, 20, 60)]  // 20% de desconto
        [InlineData(20, 5, 20)]   // 20% de desconto
        public void ApplyDiscount_DeveAplicar20Porcento_QuandoQuantidadeEntre10e20(int quantidade, decimal precoUnitario, decimal descontoEsperado)
        {
            var item = new SaleItem { Quantity = quantidade, UnitPrice = precoUnitario };
            item.ApplyDiscount();
            item.Discount.Should().Be(descontoEsperado);
        }

        [Fact]
        public void ApplyDiscount_DeveLancarExcecao_QuandoQuantidadeMaiorQue20()
        {
            var item = new SaleItem { Quantity = 21, UnitPrice = 10 };
            Action act = () => item.ApplyDiscount();
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Cannot sell more than 20 identical items.");
        }
    }
} 