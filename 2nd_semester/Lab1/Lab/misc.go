package main

import (
	"bufio"
	"os"
	"strconv"
	"strings"
)

func parseNumbers(s string) []int {
	var n []int
	for _, f := range strings.Fields(s) {
		i, err := strconv.Atoi(f)
		if err == nil {
			n = append(n, i)
		}
	}
	return n
}

func getInputSlice() []int {
	scanner := bufio.NewScanner(os.Stdin)
	scanner.Scan()
	return parseNumbers(scanner.Text())
}

func distinct(arr []int) []int {
	unique := make(map[int]bool)
	result := []int{}
	for _, val := range arr {
		if !unique[val] {
			unique[val] = true
			result = append(result, val)
		}
	}

	return result
}
