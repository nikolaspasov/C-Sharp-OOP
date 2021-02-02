// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
	using System.Linq;

	[TestFixture]
	
	public class StageTests
    {
		Stage stage;
		Song song;
		Performer performer;

		[SetUp]
		public void SetUp()
		{
			 stage = new Stage();
			song = new Song("SongTest", new TimeSpan(0, 3, 30));
			performer = new Performer("first", "last", 20);
		}

		[Test]
	    public void AddPerformerIsNull()
	    {
			performer = null;
			Assert.Throws<ArgumentNullException>(() =>
		   {
			   stage.AddPerformer(performer);
		   });
		}
		[Test]
	    public void AddPerformerUnder18()
	    {
			performer = new Performer("name","namee",10);
			Assert.Throws<ArgumentException>(() =>
		   {
			   stage.AddPerformer(performer);
		   });
		}
		[Test]
	    public void AddPerformerWorks()
	    {
			performer = new Performer("name","namee",19);
			stage.AddPerformer(performer);
			 Assert.AreEqual(stage.Performers.Count, 1);
		  
		}
		[Test]
	    public void AddSongWorks()
	    {
			song = new Song("songname", new TimeSpan(0, 0, 30));
			Assert.Throws<ArgumentException>(() =>
			{ stage.AddSong(song); });
		  
		}
		[Test]
		public void AddSongToPerformerNullSong()
		{
			song = null;
			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSongToPerformer("123", performer.FullName);
			});
		}
		[Test]
		public void AddSongToPerformerNullPerformer()
		{
			
			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSongToPerformer(song.Name, "456");
			});
		}
		[Test]
		public void AddSongToPerformer()
		{
			performer = new Performer("Name", "Last", 20);
			stage.AddPerformer(performer);
			stage.AddSong(song);
			var res =	stage.AddSongToPerformer("SongTest", "Name Last");
			Assert.AreEqual(res, $"{song} will be performed by {performer.FullName}");

		}
		[Test]
		public void PlayMethod()
		{
			stage = new Stage();
			Performer perform = new Performer("123", "234", 43);
			stage.AddPerformer(perform);
			stage.AddSong(song);
			stage.AddSongToPerformer("SongTest", "123 234");
			Song newSong = new Song("song",new TimeSpan(0,4,0));
			stage.AddSong(newSong);
			
			stage.AddSongToPerformer("song", "123 234");

			

			Assert.AreEqual(stage.Play(), $"1 performers played 2 songs");
		}
		
	}
}