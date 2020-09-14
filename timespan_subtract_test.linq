<Query Kind="Statements" />

TimeSpan ts = new TimeSpan(0, 0, 1);
ts.Dump();

ts = ts.Subtract(TimeSpan.FromSeconds(10));
ts.Dump();

ts.Negate().Dump();