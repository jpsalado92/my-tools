Placeholder: https://doc.rust-lang.org/book/ch03-02-data-types.html#data-types

Check if rust is installed.

## Basics
```rust
// Check rust version
$ rustc --version

// Compile and run
$ rustc main.rs
```

### Cargo
Cargo is Rust’s build system and package manager.

It is used as a convention on how to manage projects.

Cargo handles a lot of tasks for you, such as building your code, downloading the libraries your code depends on, and building those libraries.

```rust
// Check cargo version
$ cargo --version

// New project
$ cargo new project_name

// Build project
$ cargo build

// Compile and run
$ cargo run

// We can build a project without producing a binary to check for errors using cargo check.
$ cargo check

// Building for Release. (This command will create an executable in target/release instead of target/debug.)
$ cargo build --release
```

## Concepts

Variables:
* You declare them using `let`.
* They are immutable by default (once a value is bound to a name, you can’t change that value)
* You can make them mutable using `let mut`.
* Example: `let x = 3;` or `let mut x = 3;`

Constants:
* They are always immutable.
* You declare them using the `const`.
* The type of the value must be annotated.
* Constants can be declared in any scope, including the global scope
* May be set only to a constant expression.
* Example: `const THREE_HOURS_IN_SECONDS: u32 = 60 * 60 * 3;`
* Convention for constants is to use all uppercase with underscores between words.

## Useful resources

[Rust reserved keywords](https://doc.rust-lang.org/book/appendix-01-keywords.html)
