<p align="center">
  <img 
    src="../assets/logo.svg" 
    width="200px"
    alt="Neo">
</p>

<p align="center" style="font-size: 48px;">
  <strong>Workshop 004: Smart Contracts 2 - Decentralized Application Architectures and Design Considerations</strong>
</p>

# Introduction
* <b>Duration:</b> 
	* 1 Hour
* <b>Prerequisites:</b> 
	* [003 Smart Contracts 1](../3_smart_contract_1/README.md)
* <b>Infrastructure Requirements:</b>
	* (Required) Whiteboard or Projector
	* (Required) High-Speed Internet Connection
* <b>Instructor Prework:</b>
	* (Required) Workshop content review
	* (Required) Eventnet setup
* <b>Student Prework:</b>
	* (Recommended) General Understanding of blockchain fundamentals
	* (Recommended) Familiarization with Amazon Web Services(or other CSP)
* <b>Workshop Materials List:</b>
	* None

## Outline
Decentralized applications can adopt many architectures. In this workshop, we will discuss a number of them as well as unique design considerations based on the Neo's features as well as its economy. This workshop will be language agnostic, but it is recommended that participants have completed Smart Contract Development 1.

## Key Application Differentiators
* Immutability
* Publicity of content
* Asynchronous
* Public contract code (in most cases)
* Business Logic and Financial Logic intertwined

## Fully Decentralized Architecture
{{architecture graphic}}
* Application only interfaces with blockchain via the rpc methods
* Pros
   * Fully decentralized (except for application hosting)
   * Lightweight (maintenance and operational costs)
* Cons
   * Limited SDK
   * Limited to capability of VM
   * Limited to client or remote compute (depending on architecture)

## Hybrid
{{architecture graphic}}
* Application interfaces with blockchain and other server depending on use
* Neon wallet example
Pros:
   * Sensitive events still transit to blockchain without middle-man (unless MitM attack...make sure to comment on importance of running a node for this)
   * Get flexibility of using another system to extend server-side features
Cons:
   * Maintenance and Ops costs
