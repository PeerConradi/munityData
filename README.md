# MUNity Base
[![NuGet Badge](https://buildstats.info/nuget/MUNityBase)](https://www.nuget.org/packages/MUNityBase/)

## About
A repository for the base logic used by MUNity both the Client and the Server.
This project contains the functionality for the List of Speakers and Resolution Editor, aswell as the Schema used by the Client and Server to communicate.

Use this package to create your own logic of a MUN Client or Server or help us working on MUNity.

## Getting started

You can simply install this package with:

```
PM> Add-Package MUNityBase
```

## Use the List of Speakers

```chsarp
#using MUNity.Extensions.LoSExtensions;     // For the functionality
#using MUNitySchema.Models.ListOfSpeakers;  // For the general object Structure
```

The base logic could be like this:
```chsarp
var listOfSpeakers = new ListOfSpeakers();
listOfSpeakers.AddSpeaker("Germany", "de");
listOfSpeakers.AddSpeaker("France", "fr");
// Add this point Speakers will contain: Germany and France.
listOfSpeakers.NextSpeaker();
// Now the Speakers will only contain France the CurrentSpeaker will be Germany.
listOfSpeakers.StartSpeaker();
// This will start the Speaker list. The RemainingSpeakerTime will now change every
// time you call it.
```
