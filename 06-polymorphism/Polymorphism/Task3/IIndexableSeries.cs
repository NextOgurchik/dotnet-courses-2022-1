public interface ISeries
{
	double GetCurrent();
	bool MoveNext();
	void Reset();
}
public interface IIndexable
{
	double this[int index] { get; }
}
interface IIndexableSeries : ISeries, IIndexable
{
}