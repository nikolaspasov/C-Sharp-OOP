using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyLosesHealthWhenAttacked()
    {
        Dummy dummy = new Dummy(10, 10);
        Axe axe = new Axe(5, 10);

        axe.Attack(dummy);
        Assert.That(dummy.Health, Is.EqualTo(5));
    }
    [Test]
    public void DeathDummyThrowsExceptionIfAttacked()
    {
        Dummy dummy = new Dummy(0, 10);
        Assert.That(() =>
        dummy.TakeAttack(2),
        Throws.InvalidOperationException.With.Message.EqualTo
        ("Dummy is dead."));
    
    }
    [Test]
    public void DeadDummyGivesXP()
    {
        Dummy dummy = new Dummy(0, 10);
       int xp = dummy.GiveExperience();

        Assert.That(xp, Is.EqualTo(10));
    }
    [Test]
      public void AliveDummyCannotGiveXP()
    {
        Dummy dummy = new Dummy(1, 10);
       
        Assert.That(() =>
        dummy.GiveExperience(),
        Throws.InvalidOperationException.With.Message.EqualTo
        ("Target is not dead."));
    }


}
