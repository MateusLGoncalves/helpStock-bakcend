namespace HelpStockApp.Domain.Test;
using FluentAssertions;
using HelpStockApp.Domain.Entities;
using HelpStockApp.Domain.Validation;
using Xunit;

public class CategoryUnitTest
{
    [Fact(DisplayName = "Create Category With Category Name Alone Parameter")]
    public void CreateCategory_WithCategoryNameAloneParameter_ResultObjectsValidState()
    {
        Action action = () => new Category( "Eletronics");
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category With Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectsValidState()
    {
        Action action = () => new Category(1, "Eletronics");
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category With Invalid Id")]
    public void CreateCategory_WithInvalidParametersId_ResultException()
    {
        Action action = () => new Category(-1, "Eletronics");
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }

    [Fact(DisplayName = "Create Category With Name Too Short Parameter")]
    public void CreateCategory_WithTooShortParametersName_ResultException()
    {
        Action action = () => new Category(1, "El");
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name, minimum 3 characters");
    }

    [Fact(DisplayName = "Create Category With Name Null Parameter")]
    public void CreateCategory_WithNameNullParameter_ResultException()
    {
        Action action = () => new Category(1, null);
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name, name is required!");
    }

    [Fact(DisplayName = "Create Category With Name Missing Parameter")]
    public void CreateCategory_WithNameMissingParameter_ResultException()
    {
        Action action = () => new Category(1, "");
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name, name is required!");
    }

    

    

}
