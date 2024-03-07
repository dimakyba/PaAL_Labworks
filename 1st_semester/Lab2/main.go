package main

import (
	"fmt"
	"math"
)

func DoBlock1() {
	fmt.Println("Дана послідовність з n цілих чисел. Знайти суму елементів з непарними номерами з цієї послідовності.")
	fmt.Print("Введіть значення n: ")
	var n int
	fmt.Scan(&n)
	sum := 0

	for i := 1; i <= n; i++ {
		var k int
		fmt.Scan(&k)
		if i%2 == 1 {
			sum += k
		}
	}

	fmt.Println(sum)
}

func DoBlock2() {
	fmt.Println("Дана послідовність цілих чисел, за якою слідує 0. Знайти номер мінімального елементу в цій послідовності.")

	min := math.MaxInt32
	minIndex := 0
	currentIndex := 1
	var i int
	fmt.Scan(&i)

	for i != 0 {

		if i < min {
			min = i
			minIndex = currentIndex
		}

		currentIndex++
		fmt.Scan(&i)
	}

	fmt.Println("Номер мінімального елемента:", minIndex)
}

func DoBlock3() {
	fmt.Println("S = sin(x + cos(2x + sin(3x + cos(4x + sin(5x + cos(6x +...)...) (до sin(nx) чи cos(nx) включно, sin(nx) чи cos(nx) залежить від парності n);")
	fmt.Print("Введіть n: ")
	var n int
	fmt.Scan(&n)
	fmt.Print("Введіть x: ")
	var x int
	fmt.Scan(&x)
	var solution float64

	if n%2 == 0 {
		solution = math.Cos(float64(n) * float64(x))
	} else {
		solution = math.Sin(float64(n) * float64(x))
	}
	n--
	for n > 0 {
		if n%2 == 0 {
			solution = math.Cos(float64(n)*float64(x) + solution)
		} else {
			solution = math.Sin(float64(n)*float64(x) + solution)
		}
		n--
	}
	solution = math.Sin(solution)
	fmt.Println(solution)
}

func main() {
	var choice int
	for {
		fmt.Println("Для виконання блоку 1 (варіант 5) введіть 1")
		fmt.Println("Для виконання блоку 2 (варіант 25) введіть 2")
		fmt.Println("Для виконання блоку 3 (варіант 62) введіть 3")
		fmt.Println("Для виходу з програми введіть 0")
		fmt.Scan(&choice)
		switch choice {
		case 1:
			fmt.Println("Виконую блок 1")
			DoBlock1()
		case 2:
			fmt.Println("Виконую блок 2")
			DoBlock2()
		case 3:
			fmt.Println("Виконую блок 3")
			DoBlock3()
		case 0:
			fmt.Println("Зараз завершимо, тільки натисніть будь ласка ще раз Enter")
			fmt.Scanln()
		default:
			fmt.Printf("Команда ``%d'' не розпізнана. Зробіь, будь ласка, вибір із 1, 2, 3, 0.\n", choice)
		}
	}
}
