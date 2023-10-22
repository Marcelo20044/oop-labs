using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

public abstract record BuildResult
{
    private BuildResult() { }

    public record Success(PersonalComputer Computer) : BuildResult;

    public record SuccessWithComment(PersonalComputer Computer, string Comment) : BuildResult;

    public record SuccessWithDisclaimerOfWarranty(PersonalComputer Computer, string Disclaimer) : BuildResult;

    public record InvalidBuild() : BuildResult;
}