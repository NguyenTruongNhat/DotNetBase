using FluentAssertions;
using NetArchTest.Rules;

namespace INuBase.Architecture.Tests;

public class ArchitectureTests
{
    private const string DomainNamespace = "INuBase.Domain";
    private const string ApplicationNamespace = "INuBase.Application";
    private const string InfrastructureNamespace = "INuBase.Infrastructure";
    private const string PersistenceNamespace = "INuBase.Persistence";
    private const string PresentationNamespace = "INuBase.Presentation";
    private const string ApiNamespace = "INuBase.API";

    #region =============== Infrastructure Leyer ===============

    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProject()
    {
        var assemly = Domain.AssemblyReference.Assembly;
        var otherProject = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            PersistenceNamespace,
            PresentationNamespace,
            ApiNamespace,
        };

        var testResult = Types
            .InAssembly(assemly).ShouldNot().HaveDependencyOnAny(otherProject).GetResult();
        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = Application.AssemblyReference.Assembly;

        var otherProjects = new[]
        {
            InfrastructureNamespace,
            //PersistenceNamespace, // Due to Implement sort multi columns by apply RawQuery with EntityFramework
            PresentationNamespace,
            ApiNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = Infrastructure.AssemblyReference.Assembly;

        var otherProjects = new[]
        {
            PresentationNamespace,
            ApiNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Persistence_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = Persistence.AssemblyReference.Assembly;

        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            PresentationNamespace,
            ApiNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Presentation_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = Presentation.AssemblyReference.Assembly;

        var otherProjects = new[]
        {
            InfrastructureNamespace,
            ApiNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }
    #endregion


    #region =============== Command ===============
    [Fact]
    public void Command_Should_Have_NamingConventionEndingCommand()
    {

    }



    #endregion


    #region =============== Query ===============

    #endregion
}




