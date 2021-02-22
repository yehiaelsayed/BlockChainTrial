
# BlockChain Sample buitl with ASP.Net Core
### _A simple trail to under stand BlockChain_



## How To Run 
##### Navigate to the "BlockChainAPI" folder then open CMD and write
```
dotnet run
```

## EndPoints 
#### All end points with request parameters are represented in this file :
`BlockChain.postman_collection.json`
* /AddPeer
>This endpoint simulate a that a peer connected to the network it accept an int parameter with value from 1 to 10 represent the computing power of the peer machine 
* /AddTransaction 
> This Add point allow you to add transaction from peer to peer you can use peers addresses . This and point will intiate adding a new block with the transaction data to the chain
> 
* /GetChian
>get all blocks in the chain 

* /Peers 
> list all peers in the network you can also check the network status in the console logs
