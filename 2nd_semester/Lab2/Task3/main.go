package main

import (
	"fmt"
	"math/rand"
	"time"
)

func main() {
	fmt.Println("Labwork #7")
	fmt.Println("Task #3, Variant #12")
	fmt.Println("Упорядкувати побічну діагональ матриці від мінімального ліворуч-унизу до максимального праворуч-угорі; вважати, що матриця гарантовано квадратна.\n")

	var size uint
	fmt.Print("Введіть розмір матриці (n x n): ")
	fmt.Scan(&size)

	fmt.Println("Виберіть як ви хочете ввести масив:")
	fmt.Println("1. Вручну")
	fmt.Println("2. Автоматично, псевдо-випадковими числами")

	var choiceOfInput int
	fmt.Scan(&choiceOfInput)

	var matrix [][]int
	switch choiceOfInput {
	case 1:
		matrix = generateMatrixFromUserInput(size)
	case 2:
		matrix = generateRandomSquareMatrix(size)
	default:
		fmt.Println("Invalid choice.")
	}

	if matrix != nil {
		printSquareMatrix(matrix)
		sortSecondaryDiagonalOfMatrix(matrix)
		printSquareMatrix(matrix)
	}
}

func generateRandomSquareMatrix(size uint) [][]int {
	matrix := make([][]int, size)
	rand.Seed(time.Now().UnixNano())

	for i := uint(0); i < size; i++ {
		matrix[i] = make([]int, size)
		for j := uint(0); j < size; j++ {
			matrix[i][j] = rand.Intn(200) - 99 // generates numbers in range [-99, 100)
		}
	}

	return matrix
}

func generateMatrixFromUserInput(size uint) [][]int {
	matrix := make([][]int, size)

	for i := uint(0); i < size; i++ {
		matrix[i] = make([]int, size)
		for j := uint(0); j < size; j++ {
			fmt.Printf("Введіть [%d,%d]: ", i+1, j+1)
			fmt.Scan(&matrix[i][j])
		}
	}

	return matrix
}

func printSquareMatrix(matrix [][]int) {
	for _, row := range matrix {
		fmt.Print("(")
		for _, val := range row {
			fmt.Printf("%4d ", val)
		}
		fmt.Println(")")
	}
}

func sortSecondaryDiagonalOfMatrix(matrix [][]int) {
	size := uint(len(matrix))
	secondaryDiagonal := make([]int, size)

	for i := uint(0); i < size; i++ {
		secondaryDiagonal[i] = matrix[i][size-1-i]
	}

	quickSort(secondaryDiagonal, 0, int(size)-1)

	fmt.Println("\nСортую побічну діагональ матриці знизу вверх:")

	for i := uint(0); i < size; i++ {
		matrix[i][size-1-i] = secondaryDiagonal[size-1-i]
	}
}

func quickSort(array []int, leftIndex, rightIndex int) {
	if leftIndex < rightIndex {
		partitionIndex := partition(array, leftIndex, rightIndex)
		quickSort(array, leftIndex, partitionIndex-1)
		quickSort(array, partitionIndex+1, rightIndex)
	}
}

func partition(array []int, leftIndex, rightIndex int) int {
	pivot := array[rightIndex]
	i := leftIndex - 1

	for j := leftIndex; j < rightIndex; j++ {
		if array[j] < pivot {
			i++
			array[i], array[j] = array[j], array[i]
		}
	}
	array[i+1], array[rightIndex] = array[rightIndex], array[i+1]
	return i + 1
}
