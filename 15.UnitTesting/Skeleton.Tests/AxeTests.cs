using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    public void AxeLosesDurabilityAfterAttacking()
    {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);

        axe.Attack(dummy);
        Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
        
    }
    [Test]
    public void AxeShouldThrowExceptionIfBroken()
    {
        Assert.Throws<InvalidOperationException>(() =>
        {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(10, 10);
            axe.Attack(dummy);
        },"Axe is  broken.");
    }
}