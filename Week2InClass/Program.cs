using Week2InClass;

/*
 * So, I decided to write this in .NET 6.0 because its the first project. If you suggest working more in 5.0, I can totally do that for the remainder of the course.
 * But I will say it is definitely fun having a program.cs that looks like this.
 *
 * You'll notice from the structure of this that I tried my best to follow dependency injection practices. For the most part I did pretty good about it, but it's the first assignment and I'm sure no one else is doing this much.
 * But, with it being my second time through here, I want to make sure I do as best as possible. So please be as critical as you feel like.
 */

var file = "tickets.csv";

ApplicationStarter applicationStarter = new ApplicationStarter();
ApplicationStarter.Start(file);