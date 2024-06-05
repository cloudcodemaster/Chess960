 int counter = 1; 
 
 foreach (string position in GenerateChess960Positions())
        {
            Console.WriteLine(counter + " " + position);
            counter++;
        }
Console.ReadLine();

static IEnumerable<string> GenerateChess960Positions()
    {
        for (int b1 = 0; b1 < 8; b1 += 2)
        {
            for (int b2 = 1; b2 < 8; b2 += 2)
            {
                for (int q = 0; q < 8; q++)
                {
                    if (q == b1 || q == b2) continue;

                    for (int n1 = 0; n1 < 8; n1++)
                    {
                        if (n1 == b1 || n1 == b2 || n1 == q) continue;

                        for (int n2 = n1 + 1; n2 < 8; n2++)
                        {
                            if (n2 == b1 || n2 == b2 || n2 == q) continue;

                            List<int> remaining = new List<int>();
                            for (int i = 0; i < 8; i++)
                            {
                                if (i != b1 && i != b2 && i != q && i != n1 && i != n2)
                                    remaining.Add(i);
                            }

                            foreach (var pos in GetRookKingPositions(remaining))
                            {
                                yield return GeneratePosition(b1, b2, q, n1, n2, pos[0], pos[1], pos[2]);
                            }
                        }
                    }
                }
            }
        }
    }

    static IEnumerable<int[]> GetRookKingPositions(List<int> positions)
    {
        for (int i = 0; i < positions.Count; i++)
        {
            for (int j = i + 1; j < positions.Count; j++)
            {
                int k = positions.Find(x => x != positions[i] && x != positions[j]);
                if ((positions[i] < k && k < positions[j]) || (positions[j] < k && k < positions[i]))
                    yield return new int[] { positions[i], positions[j], k };
            }
        }
    }

    static string GeneratePosition(int b1, int b2, int q, int n1, int n2, int r1, int r2, int k)
    {
        char[] position = new char[8];
        position[b1] = 'B';
        position[b2] = 'B';
        position[q] = 'Q';
        position[n1] = 'N';
        position[n2] = 'N';
        position[r1] = 'R';
        position[r2] = 'R';
        position[k] = 'K';
        return new string(position);
    }