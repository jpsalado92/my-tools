# Algorithms and Data Structures

## Asymptotic analysis of algorithms

**Asymptotic analysis** or **complexity analysis** is the measurement of how the inputs of an algorithm affect the behavior of the algorithm, as they inputs approach some limit.

**Big O** notation represents the upper limit or worst-case-scenario of an algorithms cost, and just as Big O represents the higher bound of an algorithm, **Big Omega** represents the lower bound.

When writing Big O, values that do not change the overall shape of the curve are ignored.:

```
O(n+1) = O(n)
O(2n) = O(n)
```

Common cases:

* `O(1)`: The cost of the algorithm is unchaged by the input size.
* `O(log n)`: The cost of the algorithm scales logarithmycally with the size of the input. Dividing a problem into smaller problems leads to this complexity.
* `O(n)`: The cost of the algorithm scales linearly with the size of the input. Iterating through a collection of data often leads to this complexity.
* `O(n^2)`: The cost of the algorithm scales quadratically with the size of the input. A doubly-nested loop is an indication that we might be dealing with this complexity.
* `O(nm)`: For functions with more than one input, we add "m", that represents the size of the second input. Could end up being either O(n) or O(n^2). One must understand the domain of the problem to, in the case of O(nm) complexity, understand towards with extreme the complexity is biased.

> Note that Big O represents the worst case scenario, but there are more cases!
> For example, the quicksort algorithm has a worst-case-scenario cost of O(n^2), but its average cost is O(nlogn)

## Linked lists

* **Linked list:** Data structure in which data is stored in nodes consisting of a single data item and a reference to the next node.

* **Singly linked list:** A linked list that provides forward iteration from the start to the end of the list.
* **Doubly linked list:** A linked list that provides forward iteration from the start to the end of the list, and reverse iteration, from end to start.

* **Sorted linked list:** A doubly linked list where the values are inserted and stored in sort-order.

## Stacks and Queues

* **Stack:** It is a data structure that works as a last in first out (LIFO) container. Think of a stack of plates.
* **Queues:** It is a data structure that works as a lirst in first out (FIFO) data structure. Think of it as a queue of persons. The first element in the queue is the "head" and the last is the "tail". Whenever a new element is included it is called **enqueuing** and whenever an item is processed it is called **dequeuing**.
* **Dequeue:** Deque or Double Ended Queue is a type of queue in which insertion and removal of elements can either be performed from the front or the rear.

## Binary Trees

A tree is data structure where nodes are linked in a **parent-child relationship**.

Tree properties:

* A tree has a **root** node, the top-most node in the tree.
* Each node has either non or one parent.
* The maximum number of children a node can have goes from 0 to N, and it is known as **degree of the tree**.
* Nodes that have no children are called **leaf nodes**.
* Every node contains one data item.
* They are recursively defined, meaning that you can think that trees contain other trees inside.
* Every node is connected to each other by **edges**.
* We call **internal nodes** to those that are neither the leaf or root node.
* The **height of the node** is the maximum number of edges between that node and a leaf.
* The **level of the node** is 1 plus the number of edges between that node and the root.

Binary tree properties:

* Every node can only have, at most, 2 children, thus, it is a tree of dregree 2.

> Trees growing faster than they grow deeper is one of the reasons that trees are such an efficent data structure for storing and accessing data.

### Binary Search Tree

It is a binary tree where nodes with lesser values are placed to the left of the root, and nodes with equal or greater values are placed to the right. The smaller value will be the left-most node, whereas the maximum value will be the right-most one.
> This property is what distinguishes a binary tree from a binary search tree.

Insertion/Search/Removal in a BST normally has an average time complexity of `O(logn)`, but in some corner cases (imagine inserting values from lowest to greatest) it is `O(n)`.

### Tree traversals

Algorithms that visit every node in a tree processing them in a specific order.

**Pre-order** "The node is visited before it's children"

* **Complexity:** `O(n)`
* **Operations:** `Process Current Value - Visit Left Child - Visit Right Child`
* **Usage:** Make a copy of the Btree.

**In-order** "The left child is visited before the node, then the right child"

* **Complexity:** `O(n)`
* **Operations:** `Visit Left Child - Process Current Value - Visit Right Child`
* **Usages:** Return an ordered list of all the data.

**Post-order**: "The left and right children are visited before the node"

* **Complexity:** `O(n)`
* **Operations:** `Visit Left Child - Visit Right Child - Process Current Value`
* **Usages:** Delete every node in a tree, subsequent deletions will always delete leaves up until the root.

### TODO Balanced Tree

The root node has roughly the same number of on the right and left side.
The height of both children is the same.
