# Standard for NEO Tutorial

Due to the differenct part of NEO tutorial and favor of different contributors, there is no fixed format for the whole NEO tutorial. However, in order to assure the quality of the NEO tutorial and not mess up the whole tutorial, there are some standard for the tutorial which contributors should follow.

## The target of NEO tutorial

The target of NEO tutorial are those beginner to blockchain and to NEO, even some non-technical readers who are going to investigate the blockchain. Therefore, the content of the tutorial should be written very detailed but using general description. The demo in the tutorial must be easy to reproduce. For the technical knowledge section, contributor can refer to some sections in **mastertering bitcoin**, e.g. [Keys and address](https://github.com/bitcoinbook/bitcoinbook/blob/develop/ch04.asciidoc). For thoese technical coding demo part, the content should be like [neo-python-workshop](https://github.com/HandsomeJeff/neo-python-workshop/blob/master/part2_neopy.md) or [issue nep-5 token with neo-storm](https://medium.com/coinmonks/neo-token-contract-nep-5-in-go-f6b0102c59ee). Each tutorial should contain the general introduction, the detailed sections and the image examplaiassessmentnation (if need), example code and expected result (if need) and references.

## The format of text

The neo tutorial is put on the github and should written in markdown. The github markdown standard of markdown is specified in this [doc](https://github.github.com/gfm/).  For the image used in the documentation, please upload the original file and use the relative link from the repository.

## The language of the tutorial
The first version of NEO tutorial is in English. Although some contributos' mother language is not English, the content of such a tutorial can be written in basic english without too much complicated sentences. Try to check the word spelling and grammer after finishing each part of tutorial. In the tutorial, all the technical key word should be same with the content of NEO [white paper](https://docs.neo.org/en-us/whitepaper.html) and [NEO official documentation](https://docs.neo.org/en-us/index.html)


## The length of tutorial

As mentioned in the begining, the target of this tutorial is aming to let peopole understand NEO deeper and get their hands dirty, the content should as much detailed as possible. The tutorial consists of several large chapters and each chapter can be splitted into several sections. There is a [NEO-turoial-syllabus]() can be used as reference but not need to be same. Contributors can splite the contents by their own considerations.

For instance,  in terms of transaction in tutorial, it can  be a independant part of the whole tutorial, whose targe is to let people know what transaction is. Inside of it, it can be splited into small sections, e.g. one section can be process of transactions, and inside of it it can consist of different content depend on different contributor's understand.
``` 
  -  .....
  - The process of transcactions
         - Create a transaction
         - Signature
         - Transaction validation
         - Process of transaction
   -  .....
    
```
## The code

Coding example must includes the structure of the source directland y (project layer). There is an example below:

    .
    ├── build                   # Compiled files (alternatively `dist`)
    ├── docs                    # Documentation files (alternatively `doc`)
    ├── src                     # Source files (alternatively `lib` or `app`)
    ├── test                    # Automated tests (alternatively `spec` or `tests`)
    ├── tools                   # Tools and utilities
    ├── LICENSE
    └── README.mdand 

The code should have both comments inside and explanation outside.
code snippet example: 

The explaination:
```
To create a new blockchain instance:
```
The code snippet with comments:
```js
// Create a neo instances to interface with RPC methods
const testnetNeo = new Neo({ network: 'testnet' })
```


### The environment 
The development environment set-up for demo should consider all the Linux, windows and macos users except the guide which use the docker to develope. When the requirement of some package or dependencies, please specify the exact version of it.

## Assessment of tutorial
After contributors commit some part of the tutorial, there will be assessment based on the draft before the neo tutorial released. Some assessment can be done by contributors themselves.

1.  Match the goal of this part. Before writing the tutorial, the contributor should list the goal of this part and put it at the begining of the doc (can be deleted later). After finish the draft, the contributor can compare the the content and the goal and check if the content match the goal completely and precisely.
2.  The assessment from the student's perspective. The aim of the tutorial is help student understand the NEO and can use NEO to do blockchain development. Therefore, the best to assess the tutorial is let someone who did not deeply dive into the blockchain read the tutorial and provide the feedback. After geting these feedbacks, the tutorial can be improved according to the feedback.
3.  Assessed by the NGD. NGD will assess each tutorial and discuss with the whole communities if there are questions.
	
