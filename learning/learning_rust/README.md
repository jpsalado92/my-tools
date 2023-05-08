Placeholder: https://doc.rust-lang.org/book/ch03-00-common-programming-concepts.html

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