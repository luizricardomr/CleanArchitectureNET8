using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Validations;
using FluentAssertions;

namespace CleanArchMVC.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create product with valid state")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99M, 99, "Product Image");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_ExceptionDomainNegativeValue()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99M, 99, "Product Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
        }
        [Fact]
        public void CreateProduct_ShortNameValue_ExceptionDomainInvalidName()
        {
            Action action = () => new Product(1, "P", "Product Description", 9.99M, 99, "Product Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters");
        }
        [Fact]
        public void CreateProduct_LongImageName_ExceptionDomainInvalidLengthImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99M, 99, "Product Imageeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image name, too long, maximum 250 characters");
        }
        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99M, 99, null);
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99M, 99, "");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.99M, 99, "");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price value");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99M, value, "");
            action.Should().Throw<DomainExceptionValidation>();
        }
    }
}