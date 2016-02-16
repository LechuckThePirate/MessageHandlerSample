# README #

Open the project with Visual Studio 2012+ and go. 

This is a sample on how to implement a message parsing and processing library that can handle incoming messages in strings and parse them, map them to DTOs and process them. 

The implementation done allows new kinds of messages to be added without changing anything in configuration, the factory, without having long enum lists and all the stuff that comes with that. If you need a new message processor, just inherit GenericResponse<T>, add the attribute [HandlesResponseType("xxxx")] and you're set, it will be automatically recognised by the factory.

** IMPORTANT ** 
Remember that this is just a sample, it has no real use on it's own, and some things could be improved since it's been created only for demonstration of some .NET techniques.

Enjoy it!

You can send any comment/request/question to joan.vilarino@gmail.com 
You can also visit my blog for more articles and demos http://mycodingcorner.es