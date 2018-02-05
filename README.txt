BACKGROUND

The idea is that we have a pile of straw (the haystack).
Each piece of straw has color and length values associated to it.
Our goal is to organize the pile of straw into groups of color, ordered by their length.
We also would like any duplicate pieces of straw removed from the groups.


REQUIREMENTS

1)create an implementation of the [IHaystackOrganizer] interface.
2)demonstrate the execution of your [IHaystackOrganizer] implementation with a Unit Test.
3)sort the [Haystack] "pile" of [Straw] into their associated color-groups on the [SortByColorResult] object
	A) classify [Straw] instance as "reds" when the "ColorRed" value is greater than both the "ColorGreen" and "ColorBlue" values
	B) classify [Straw] instance as "greens" when the "ColorGreen" value is greater than both the "ColorRed" and "ColorBlue" values
	C) classify [Straw] instance as "blues" when the "ColorBlue" value is greater than both the "ColorRed" and "ColorGreen" values
	D) classify [Straw] instance as "grays" when the "ColorRed", "ColorGreen" and "ColorBlue" values are the same
	E) two of the color values are the same but both are greater than the third, MUST classify [Straw] instance
		as one of the two color values that are the same (your call which bucket to group the instance under)
		i)Example: "red=200", "green=200", "blue=100", straw is neither "red-dominant" nor "green-dominant"
			so we must choose to default it to either the "red" or "green" bucket.
		
4) order each list of [Straw] on the [SortByColorResult] object by the [Straw] object's "LengthInCm" value
	A) SHOULD be ordered from smallest to largest
5) remove any [Straw] instances that are considered to be a duplicate
	A) Same "ColorRed", "ColorGreen", "ColorBlue" and "LengthInCm" values as an instance that has already been sorted.

HELP/TROUBLESHOOTING

-) Application is throwing an [OutOfMemoryException]:
	Try making the "PILE_SIZE_MIN" and "PILE_SIZE_MAX" values smaller within the [Haystack] object