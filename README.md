# RSSReader
Want to listen to your favorite podcasts? 
Want to be able to see new episodes as fast as possible?
If yes, subscribe to different feeds and give them your own categories and updating intervals because it's all customizable. 
This is RSSReader, your place for podcasts.

![main3](https://user-images.githubusercontent.com/60555651/97229689-08eca280-17d9-11eb-87c2-25039fc5eca9.PNG)
![episode](https://user-images.githubusercontent.com/60555651/97228687-9202da00-17d7-11eb-8179-e51e411879f6.PNG)

This project involves creating a RSS feed reader that uses a multitier architecture and in this case the "Repository pattern",
1. Presentation layer
2. Bussiness layer.
3. Data access layer.
4. Data layer.

More about it here: https://en.wikipedia.org/wiki/Multitier_architecture

The use of this software design gives an array of benefits which are:
1. You have the data access layer modifying the data layer creating an abstraction layer between bussiness layer and the data layer. This makes it easy to scale the system 
without having to change too much code. 

Example: If you have a Microsoft SQL database and want to change it to mySQL you only have to modify the data layer and no other layer needs to be modified.

2. Easy to test! With the data access layer you get the methods for modifying the data layer making it really simple to test your code whenever needed.

There are also several more benefits with this pattern.

Application functionality:
1. The application built is using Winform as the presentation of components and C# as backend.
2. The data layer accesses local files both XML and JSON to store/retrieve data. (With this pattern we can with ease implement a database instead!)
3. Automatic fetching of RSS feeds using asynchronous threading to update the data real time.
4. Modifying all data which includes (Create, Reading, Updating, Deleting).
5. Play the soundfiles after the application downloads the MP3 file locally. 

This requirement specification was created for the C# OOP class for autumn term 2020.

Future improvements/developments:
1. Add parallel threading to update all feeds.
2. Make the UI more stylish.
3. Add a database.
4. Add MP3 audio controls.
5. Add favorites etc...
