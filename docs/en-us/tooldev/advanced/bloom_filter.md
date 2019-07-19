<center><h2> Bloom Filter </h2></center>

　Bloom filter is proposed by Bloom in 1970. It's actually a wide binary vector and a series of random mapping functions. Bloom filter can be used to check whether an item is within a set. Its effectiveness and query time is much better than common algorithms. The disadvantage is that there is a certain misrecognition rate and difficulty in deleting.

　NEO uses Bloom filter to verify transactions for SPV wallet.

Steps:

  1. SPV wallet broadcasts Bloom filter to all nodes, which will load this Bloom filter.

  2. SPV wallet broadcasts Bloom filter parameters to all nodes, which will load these parameters (optional).

  3. SPV wallet requests transaction data with block hash from all nodes, which will return transaction data and constructed Merkle tree path after filtering with Bloom filter.

  4. SPV wallet verifies transaction data with Merkle tree path.

  5. SPV wallet sends removing Bloom filter command to all nodes, which will remove specified filter.

Scenarios：

  1. Transaction data verification for SPV wallet