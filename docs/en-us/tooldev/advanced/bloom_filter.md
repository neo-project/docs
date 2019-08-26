# Bloom Filter

Bloom Filter is proposed by Bloom in 1970. It's actually a wide binary vector and a series of random mapping functions. Bloom Filter can be used to check whether an item is within a set. Its effectiveness and query time is much better than common algorithms. The disadvantage is that there is a certain misrecognition rate and difficulty in deleting.

NEO uses Bloom filter to verify transactions for SPV wallet.

Steps:

  1. SPV wallet broadcasts Bloom filter to a full node, which will load this Bloom filter.

  2. SPV wallet broadcasts Bloom filter parameters to the full node, which will load these parameters (optional).

  3. SPV wallet requests transaction data with block hash from the full node, which will return transaction data and constructed Merkle Tree path after filtering with Bloom filter.

  4. SPV wallet verifies transaction data with Merkle Tree path.

  5. SPV wallet sends removing Bloom Filter command to the full node which will remove the specified filter.

Scenarios：

Transaction data verification for SPV wallet
