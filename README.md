[![Build Status](https://travis-ci.org/Feasoron/red-squirrel-core.svg?branch=develop)](https://travis-ci.org/Feasoron/red-squirrel-core)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-round)](http://makeapullrequest.com)
![](https://reposs.herokuapp.com/?path=Feasoron/red-squirrel-core)

*This application is still under sporadic active development. Not all described features and functionality are implemented at this time.* 

What is Red Squirrel
--------------------

Red Squirre is a .Net Core server backend for providing management and use of food and ingredients in your home. Red Squirrel allows you to record what you have, where it is, and how much you have. Beyond that, it has built in conversions for various units, both standard (1 Gallon = 4 Cups) and food-specifc (1 cup shredded carrots = 2 carrots).  


Getting Started
---------------

To get started, all you need is a machine running .Net Core 2.0 and access to a PostgreSQL database.  Add the connection string to either your appsettings.json or your user setting, with the format

`    "ConnectionString":"Username=<name>;Password=<password>;Host=<address>;Database=<instance>"`


Contributing
------------
Bugs, feature requests and pull requests are all welcome, as long as you follow the [code of conduct](https://github.com/Feasoron/red-squirrel-core/blob/develop/CODE_OF_CONDUCT.md). 

See Also
--------
We have and Angular client!  [Red Squirrel Web](hhttps://github.com/Feasoron/red-squirrel-web)
