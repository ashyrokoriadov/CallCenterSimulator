# Call Center Simulator
* A project is a multi threading application simulating work of a call center. 
* There are 3 call center operators who response phone calls. 
* A response conversation lasts from 6 to 10 seconds. 
* The calls income constantly each 3-5 seconds. 
* If there is to much incoming calls, then they are buffered. 
* As soon as the call center operator is free, s/he is able to respond a call again. 
* It is possible to add a call manually by pressing "C" button. 
* In order to exit the application, press "Q".
## Getting Started
* The project was created in Visual Studio Community 2015 using .NET Framework 4.6.1. 
* It contains 2 models objects: 
  1. an object implementing IOperator interface and representing a call center operator 
  1. an object implementing ICall interface and representing a call
* It contains 3 classes implementing business logic defined in ICallHandler interface
  1. ThreadCallHandler - multi threading is implemented by using a Thread class;
  1. ThreadPoolCallHandler - multi threading is implemented by using a ThreadPool class;
  1. TaskCallHandler - multi threading is implemented by using a Task class;
* It contains a static helper class containing one method used for generating calls - the class was created in order to not copy a code (DRY principle)
## Versioning
Release sequence, release time and version number are defined by author. 
## Author
Andriy Shyrokoryadov.
## License
This project is licensed under the MIT License - see the LICENSE.md file for details.

