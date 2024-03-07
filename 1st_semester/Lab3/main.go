package main

import (
	"fmt"
	"math"
)

func main() {

	fmt.Println("Введіть значення n: ")
	var n int
	fmt.Scan(&n)
	fmt.Printf("Виводжу прості числа вигляду q^2 + 1 від 2 до %d:\n", n)
	print_all_Q_Pow_2_prime_numbers(n)
	fmt.Println()
	fmt.Printf("Виводжу прості числа Фібоначчі від 2 до %d:\n", n)
	print_all_fibonacci_prime_numbers(n)
}

func is_prime(number int) bool {
	if number <= 1 {
		return false
	}
	if number <= 3 {
		return true
	}

	if number%2 == 0 || number%3 == 0 {
		return false
	}

	i := 5
	for i*i <= number {
		if number%i == 0 || number%(i+2) == 0 {
			return false
		}
		i += 6
	}

	return true
}

func print_all_Q_Pow_2_prime_numbers(n int) {
	for i := 2; i <= n; i++ {
		if math.Mod(math.Sqrt(float64(i-1)), 1) == 0 && is_prime(i) {

			fmt.Printf("%d ", i)
		}

	}

}

func print_all_fibonacci_prime_numbers(n int) {
	num1 := 1
	num2 := 1
	var temp int
	for num2 <= n {
		if is_prime(num2) {
			fmt.Printf("%d ", num2)
		}
		temp = num1
		num1 = num2
		num2 = num1 + temp
	}
}
