using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Validations;
using FluentAssertions;
using System.Security.Cryptography.X509Certificates;

namespace CleanArchMVC.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName ="Create category with valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_ResultObjectValidState()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id. Id must be greater than zero.");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_ResultObjectValidState()
        {
            Action action = () => new Category(1, "C");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateCategory_MissingValueName_ResultObjectValidState()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }

        [Fact]
        public void CreateCategory_WithNullValueName_ResultObjectValidState()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }
    }
}