package main

import (
	"fmt"
)

func main() {
	var input []int
	isValidInput := false
	for !isValidInput {
		fmt.Println("Please enter 3 integers:")
		input = getInputSlice()
		if len(input) == 3 {
			if !isSorted(input) {
				insertionSort(input)
			}
			printAllPermutations(input)

			isValidInput = true
		} else {
			fmt.Println("There aren't 3 integers, please try again")
		}

	}

}

func isSorted(arr []int) bool {
	for i := 0; i < len(arr)-1; i++ {
		if arr[i] > arr[i+1] {
			return false
		}
	}

	return true
}

func insertionSort(array []int) []int {
	length := len(array)
	for i := 1; i < length; i++ {
		key := array[i]
		j := i - 1

		for j >= 0 && array[j] > key {
			array[j+1] = array[j]
			j--
		}
		array[j+1] = key
	}

	return array
}

func printAllPermutations(array []int) {
	n := len(array)
	size := factorial(n)
	outerArray := make([][]int, size)

	count := 0

	for i := 0; i < n; i++ {
		for j := 0; j < n; j++ {
			for k := 0; k < n; k++ {
				if i != j && i != k && j != k {
					outerArray[count] = []int{array[i], array[j], array[k]}
					count++

				}
			}
		}
	}
	filteredArray := getDistinctRowsOfMatrix(outerArray)
	permutations := len(filteredArray)
	uniqueNumbers := len(distinct(array))
	fmt.Printf("There are %d unique permutation with %d unique numbers:\n", permutations, uniqueNumbers)
	printMatrix(filteredArray)
}

func printMatrix(arr [][]int) {
	for _, innerArr := range arr {
		fmt.Print("( ")
		for _, element := range innerArr {
			fmt.Printf("%d ", element)
		}
		fmt.Printf(")\n")
	}
}

func getDistinctRowsOfMatrix(arr [][]int) [][]int {

	var distinctArrays [][]int
	for _, innerArray := range arr {
		isDuplicate := false
		for _, distinctArray := range distinctArrays {
			if arraysAreEqual(innerArray, distinctArray) {
				isDuplicate = true
				break
			}
		}
		if !isDuplicate {
			distinctArrays = append(distinctArrays, innerArray)
		}
	}
	return distinctArrays
}

func arraysAreEqual(arr1, arr2 []int) bool {
	if len(arr1) != len(arr2) {
		return false
	}
	for i := 0; i < len(arr1); i++ {
		if arr1[i] != arr2[i] {
			return false
		}
	}
	return true
}

func factorial(n int) int64 {
	if n < 0 {
		return -1
	}
	var result int64 = 1
	for i := 2; i <= n; i++ {
		result *= int64(i)
	}
	return result
}
