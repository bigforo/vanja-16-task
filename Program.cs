
//Shared here https://dotnetfiddle.net/McSBvx

var br = new List<int> {16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1};

var listAll4sSumTo34 = new List<List<int>>();
foreach (var combo in GetPermutations(br, 4))
    if (combo.ElementAt(0) + combo.ElementAt(1) + combo.ElementAt(2) + combo.ElementAt(3) == 34)
        listAll4sSumTo34.Add(combo.ToList());


foreach (var row1 in listAll4sSumTo34.Take(1))
{
    var elementsInUse = new List<int>()
    {
        row1[1],row1[2],row1[3]
    };
    foreach (var col1 in listAll4sSumTo34) // COLUMN 1
        if (col1[0] == row1[0] && !elementsInUse.Contains(col1[1]) && !elementsInUse.Contains(col1[2]) && !elementsInUse.Contains(col1[3]))
        {
            var elementsInUse2 = new List<int>
            {
                row1[0],row1[1],row1[2],row1[3],

                col1[2],
                col1[3]
            };
            foreach (var row2 in listAll4sSumTo34) // ROW 2
                if (row2[0] == col1[1] && !elementsInUse2.Contains(row2[1]) && !elementsInUse2.Contains(row2[2]) && !elementsInUse2.Contains(row2[3]))
                {
                    var elementsInUse3 = new List<int>
                    {
                        row1[0],row1[1],row1[2],row1[3],
                        col1[1],row2[1],row2[2],row2[3],
                                
                        col1[3],
                    };
                    foreach (var row3 in listAll4sSumTo34) // ROW 3
                            
                        if (row3[0] == col1[2] && !elementsInUse3.Contains(row3[1]) && !elementsInUse3.Contains(row3[2]) && !elementsInUse3.Contains(row3[3]))
                        {
                            var elementsInUse4 = new List<int>
                            {
                                row1[0],row1[1],row1[2],row1[3],
                                col1[1],row2[1],row2[2],row2[3],
                                col1[2],row3[1],row3[2],row3[3]

                            };
                            foreach (var row4 in listAll4sSumTo34) // ROW 4
                                if (row4[0] == col1[3] && !elementsInUse4.Contains(row4[1]) && !elementsInUse4.Contains(row4[2]) && !elementsInUse4.Contains(row4[3]))
                                {
                                    if ((row1[1] + row2[1] + row3[1] + row4[1] == 34)
                                        && (row1[2] + row2[2] + row3[2] + row4[2] == 34)
                                        && (row1[3] + row2[3] + row3[3] + row4[3] == 34))
                                    {
                                        Console.WriteLine($"┌──┬──┬──┬──┐");
                                        Console.WriteLine($"│{row1[0]:00}│{row1[1]:00}│{row1[2]:00}│{row1[3]:00}│");
                                        Console.WriteLine($"├──┼──┼──┼──┤");
                                        Console.WriteLine($"│{row2[0]:00}│{row2[1]:00}│{row2[2]:00}│{row2[3]:00}│");
                                        Console.WriteLine($"├──┼──┼──┼──┤");
                                        Console.WriteLine($"│{row3[0]:00}│{row3[1]:00}│{row3[2]:00}│{row3[3]:00}│");
                                        Console.WriteLine($"├──┼──┼──┼──┤");
                                        Console.WriteLine($"│{row4[0]:00}│{row4[1]:00}│{row4[2]:00}│{row4[3]:00}│");
                                        Console.WriteLine($"└──┴──┴──┴──┘");
                                    }
                                }
                        }
                }
        }
}

static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
{
    if (length == 1) return list.Select(t => new T[] { t });

    return GetPermutations(list, length - 1)
           .SelectMany(t => list.Where(e => !t.Contains(e)), (t1, t2) => t1.Concat(new T[] { t2 }));
}


