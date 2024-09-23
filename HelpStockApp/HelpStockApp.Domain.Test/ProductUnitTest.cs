using FluentAssertions;
using HelpStockApp.Domain.Entities;
using HelpStockApp.Domain.Validation;
using Xunit;

namespace HelpStockApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Testes Positivos de Produto
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParemeters_ResultObejectsValidState()
        {
            Action action = () => new Product(0, "Product", "Description", 100, 10, "URL");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        #endregion

        #region Testes Negativos de Produto 
        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_WithInvalidParemetersId_ResultException()
        {
            Action action = () => new Product(-1, "Product", "Description", 100, 10, "URL");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Product With Invalid Name Null")]
        public void CreateProduct_WithInvalidParemetersNameNull_ResultException()
        {
            Action action = () => new Product(0, null, "Description", 100, 10, "URL");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required!");
        }

        [Fact(DisplayName = "Create Product With Invalid Name")]
        public void CreateProduct_WithInvalidParemetersNameVoid_ResultException()
        {
            Action action = () => new Product(0, "", "Description", 100, 10, "URL");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required!");
        }

        [Fact(DisplayName = "Create Product With Name Too Short Parameter")]
        public void CreateProduct_WithNameTooShortParameter_ResultException()
        {
            Action action = () => new Product(0, "Pr", "Description", 100, 10, "URL");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short. minimum 3 characters!");
        }

        [Fact(DisplayName = "Create Product With Image too long parameter")]
        public void CreateProduct_WithImageTooLongParameter_ResultException()
        {
            Action action = () => new Product(0, "Product", "Description", 100, 10, "https://img.freepik.com/fotos-premium/arvores-que-crescem-na-floresta_1048944-30368869.jpg?w=900https://img.freepik.com/fotos-premium/arvores-que-crescem-na-floresta_1048944-30368869.jpg?w=900https://img.freepik.com/fotos-premium/arvores-que-crescem-na-floresta_1048944-30368869.jpg?w=900");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image URL, too long. maximum 250 characters!");
        }

        [Fact(DisplayName = "Create Product With Image null parameter")]
        public void CreateProduct_WithImageNullParameter_ResultException()
        {
            Action action = () => new Product(0, "Product", "Description", 100, 10, null);
            action.Should().Throw<NullReferenceException>();
        }

        [Fact(DisplayName = "Create Product With Image missing parameter")]
        public void CreateProduct_WithImageMissingParameter_ResultException()
        {
            Action action = () => new Product(0, "Product", "Description", 100, 10, "");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image URL, URL is required!");
        }

        [Fact(DisplayName = "Create Product With Stock negative parameter")]
        public void CreateProduct_WithStockNegativeParameter_ResultException()
        {
            Action action = () => new Product(0, "Product", "Description", 100, -1, "URL");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Stock, stock negative value is unlikely!");
        }

        [Fact(DisplayName = "Create Product With Price negative parameter")]
        public void CreateProduct_WithPriceNegativeParameter_ResultException()
        {
            Action action = () => new Product(0, "Product", "Description", -1, 10, "URL");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Price, price negative value is unlikely!");
        }

        #endregion


    }
}
