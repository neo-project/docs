<p align="center">
  <img 
    src="../assets/logo.svg" 
    width="200px"
    alt="Neo">
</p>

<p align="center" style="font-size: 48px;">
  <strong>Workshop 003: Smart Contracts 1 - Writing, Deploying, and Invoking</strong>
</p>

# Introduction
* <b>Duration:</b> 
	* 1 Hour
* <b>Prerequisites:</b> 
	* [002 Neo Development Environments](../2_development_environment/README.md)
* <b>Infrastructure Requirements:</b>
	* (Required) Whiteboard or Projector
	* (Required) High-Speed Internet Connection
	* (Required) Deployment of an Eventnet for workshop use
* <b>Instructor Prework:</b>
	* (Required) Workshop content review
	* (Required) Fill out the [worksheet](./Worksheet.md) for students
* <b>Student Prework:</b>
	* (Recommended) General Understanding of blockchain fundamentals
	* (Recommended) Familiarization with Amazon Web Services(or other CSP)
* <b>Workshop Materials List:</b>
	* None

## Outline
This workshop covers how to use the Neo development environment to develop basic smart contracts for the Neo platform. It will also cover the deployment process as well as how to invoke the contracts. This workshop will be branching and will support C#, python, and typescript contract development and their environments.


## Tools
* <i><b>Note:</b> All code examples are flagged with a language and tool for clarity.  Depending on your implementation path, you may be using cross language libraries (for example, writing a smart contract in python, but interfacing in javascript). </i>

## Introduction and Setup
In this course we will be walking students through smart contract development including writing, deploying, and invoking.  We will primarily be using NEP5 contracts as examples, but will cover additional contracts to provide feature coverage.  When developing a smart contract for Neo, its important to understand that the contract deployment workflow has an intermediary step where the contract code is compiled from its native language into a .avm file containing bytecode which the neoVM interprets.  


<p align="center">
  <img 
	src="../2_development_environment/assets/workflow.png" 
	alt="Neo">
</p>
	
	
## Writing a contract
* Overview of contract



### Examples:

#### C#:
* [Vanilla NEP-5 template](https://github.com/neo-project/examples-csharp/blob/master/ICO_Template)
* [Moonlight NEP-5 template](https://github.com/Moonlight-io/moonlight-ico-template)
* [Neo Docs Samples](https://docs.neo.org/en-us/sc/tutorial/HelloWorld.html)
	
#### Python:
* [NEX NEP-5 Template](https://github.com/nash-io/neo-ico-template)



* Output example .avm and bytecode

## Deploying a Contract
* Overview of deployment costs
* Deployment example on event-net

## Invoking a Contract
* Invocation costs
* Example invokation using neo-gui
* Example invocation using neon.js
* Example invocation using neo-python

### Local Invokes v. Published Invokes
* Differences in how each works
* How to leverage the difference in your architecture

### Notification Events