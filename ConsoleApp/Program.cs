List<string> positions = GenerateChess960Positions();
        foreach (string position in positions)
        {
            Console.WriteLine(position);
        }
        Console.WriteLine($"Total positions: {positions.Count}");


static List<string> GenerateChess960Positions()
    {
        List<string> positions = new List<string>();
        
        // Generate all positions for the bishops
        for (int b1 = 0; b1 < 8; b1 += 2)
        {
            for (int b2 = 1; b2 < 8; b2 += 2)
            {
                // Generate all positions for the queen
                for (int q = 0; q < 8; q++)
                {
                    if (q == b1 || q == b2) continue;
                    
                    // Generate all positions for the knights
                    for (int n1 = 0; n1 < 8; n1++)
                    {
                        if (n1 == b1 || n1 == b2 || n1 == q) continue;
                        
                        for (int n2 = n1 + 1; n2 < 8; n2++)
                        {
                            if (n2 == b1 || n2 == b2 || n2 == q) continue;
                            
                            // Determine remaining positions for rooks and king
                            List<int> remaining = new List<int>();
                            for (int i = 0; i < 8; i++)
                            {
                                if (i != b1 && i != b2 && i != q && i != n1 && i != n2)
                                {
                                    remaining.Add(i);
                                }
                            }
                            
                            // Generate all valid positions for rooks and king
                            for (int i = 0; i < remaining.Count; i++)
                            {
                                for (int j = i + 1; j < remaining.Count; j++)
                                {
                                    int k = remaining.Find(x => x != remaining[i] && x != remaining[j]);
                                    
                                    // Ensure king is between the two rooks
                                    if ((remaining[i] < k && k < remaining[j]) || (remaining[j] < k && k < remaining[i]))
                                    {
                                        char[] position = new char[8];
                                        position[b1] = 'B';
                                        position[b2] = 'B';
                                        position[q] = 'Q';
                                        position[n1] = 'N';
                                        position[n2] = 'N';
                                        position[remaining[i]] = 'R';
                                        position[remaining[j]] = 'R';
                                        position[k] = 'K';
                                        
                                        positions.Add(new string(position));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        
        return positions;
    }