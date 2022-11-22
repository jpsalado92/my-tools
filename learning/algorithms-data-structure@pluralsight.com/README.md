# Algorithms and Data Structures

## Asymptotic analysis of algorithms

**Asymptotic analysis** or **complexity analysis** is the measurement of how the inputs of an algorithm affect the behavior of the algorithm, as they inputs approach some limit.

Big O notation represents the upper limit or worst-case-scenario of an algorithms cost, and just as Big O represents the higher bound of an algorithm, Big Omega represents the lower bound.

Values that do not change the overall shape of the curve are ignored.

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
