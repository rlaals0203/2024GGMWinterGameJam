using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class NotOverlapValue<T>
{
    public event Action? OnReset;

    private Random _random;

    private List<T> _range = new List<T>();
    private List<T> _values = new List<T>();

    public NotOverlapValue(IEnumerable<T> range, Random? random = null)
    {
        _range.AddRange(range);
        _values.AddRange(range);
        _random = random ?? new Random();
    }

    public NotOverlapValue(T range, Random? random = null) : this(new[] { range }, random) { }

    public NotOverlapValue(Random? random = null) : this(Enumerable.Empty<T>(), random) { }

    /// <summary>
    /// �ʱ�ȭ �� ������ �� ������ ���� �����ɴϴ�.
    /// </summary>
    public int GetRangeCount() => _range.Count;

    /// <summary>
    /// �ʱ�ȸ �Ǳ� ���� ���� ������ ���� �����ɴϴ�.
    /// </summary>
    public int GetValueCount() => _values.Count;

    /// <summary>
    /// ��(<typeparamref name="T"/>)�� ������ �߰��մϴ�.
    /// </summary>
    /// <param name="value">�߰��� ���Դϴ�.</param>
    /// <remarks>
    /// ���� �߰��� �� ���� ��쿡 ���� ���� ó���� ���ԵǾ� ���� �ʽ��ϴ�.
    /// </remarks>
    public void AddRange(T range)
    {
        if (range == null || _range.Contains(range)) return;
        _range.Add(range);
    }

    /// <summary>
    /// ������ ���� �÷����� ������ �߰��մϴ�.
    /// </summary>
    /// <param name="value">�߰��� ���� �÷����Դϴ�.</param>
    /// <remarks>
    /// null ���� ���� ���� ó���� ���ԵǾ� ���� �ʽ��ϴ�.
    /// </remarks>
    public void AddRange(IEnumerable<T> range)
    {
        if (range == null) return;

        foreach (T entry in range)
            if (!_range.Contains(entry))
                _range.Add(entry);
    }

    /// <summary>
    /// ��(<typeparamref name="T"/>)�� �Ŀ� ���� ���� �߰��մϴ�.
    /// �߰��� ���� �ʱ�ȭ ���� �ʰ� ������ϴ�.
    /// </summary>
    /// <param name="value">�߰��� ���Դϴ�.</param>
    /// <remarks>
    /// ���� �߰��� �� ���� ��쿡 ���� ���� ó���� ���ԵǾ� ���� �ʽ��ϴ�.
    /// </remarks>
    public void AddValue(T value)
    {
        if (value == null || _range.Contains(value)) return;
        _values.Add(value);
    }

    /// <summary>
    /// ������ ���� �÷����� �Ŀ� ���� ���� �߰��մϴ�.
    /// �߰��� ���� �ʱ�ȭ ���� �ʰ� ������ϴ�.
    /// </summary>
    /// <param name="value">�߰��� ���� �÷����Դϴ�.</param>
    /// <remarks>
    /// null ���� ���� ���� ó���� ���ԵǾ� ���� �ʽ��ϴ�.
    /// </remarks>
    public void AddValue(IEnumerable<T> value)
    {
        if (value == null) return;

        foreach (T entry in value)
            if (!_values.Contains(entry))
                _values.Add(entry);
    }

    /// <summary>
    /// ������ ��(<typeparamref name="T"/>)�� �����մϴ�.
    /// </summary>
    public void RangeRemove(T value) => _range.Remove(value);

    /// <summary>
    /// n��° ��(<typeparamref name="T"/>)�� �������� �����մϴ�.
    /// </summary>
    public void RangeRemoveAt(int n)
    {
        if (n >= 0 && n < _range.Count)
            _range.RemoveAt(n);
    }

    /// <summary>
    /// ������ �ʱ�ȭ�մϴ�.
    /// </summary>
    public void RangeClear() => _range.Clear();

    /// <summary>
    /// ������ �� ��ü�� �����ɴϴ�.
    /// </summary>
    /// <returns>
    /// ����(<typeparamref name="T"/>)�� ��ȯ�մϴ�.
    /// </returns>
    public IEnumerable<T> GetRange() => _range;

    /// <summary>
    /// ���� ������ �ʱ�ȭ�մϴ�.
    /// </summary>
    public void Reset()
    {
        _values = new List<T>(_range);
        OnReset?.Invoke();
    }

    /// <summary>
    /// �������� ���� ���� T���� �����ɴϴ�.
    /// �� ������ �� ������ ������ ���� ���� �������� �ʽ��ϴ�.
    /// ��, �ߺ��� ������ �����Դϴ�.
    /// </summary>
    /// <returns>������ ��� ���� �� �⺻��(<typeparamref name="T"/>)�� ��ȯ�մϴ�.</returns>
    public T GetValue()
    {
        if (_values.Count <= 0)
            Reset();

        if (_values.Count <= 0)
            return default(T);

        int randNum = _random.Next(0, _values.Count);
        T randValue = _values[randNum];
        _values.RemoveAt(randNum);
        return randValue;
    }

    /// <summary>
    /// ���� ���� ��(<typeparamref name="T"/>)�� �������� �����ɴϴ�.
    /// </summary>
    /// <returns>��(<typeparamref name="T"/>)�� ��ȯ�մϴ�.</returns>
    public T GetRangeInValue()
        => _range[_random.Next(0, _range.Count)];


    /// <summary>
    /// ������ �ε����� �ش��ϴ� ���� ��ȯ�մϴ�.
    /// </summary>
    /// <param name="n">������ ���� �ε����Դϴ�.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// �ε����� ������ ����� ��� �߻��մϴ�.
    /// </exception>
    /// <remarks>
    /// 0 �̻��� �ε����� ���Ǹ�, �ش� ���� ���� �ε������� �մϴ�.
    /// </remarks>
    public T GetValue(int n)
    {
        if (n < 0 || n >= _range.Count)
            throw new ArgumentOutOfRangeException("�ش� �Ű������� �ش��ϴ� �ε��� ���� �����ϴ�.");

        T randValue = _values[n];
        _values.RemoveAt(n);
        return randValue;
    }

    /// <summary>
    /// ������ �ε����� �ش��ϴ� ���� ���� ���� ��ȯ�մϴ�.
    /// </summary>
    /// <param name="n">������ ���� �ε����Դϴ�.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// �ε����� ������ ����� ��� �߻��մϴ�.
    /// </exception>
    /// <remarks>
    /// 0 �̻��� �ε����� ���Ǹ�, �ش� ���� ���� �ε������� �մϴ�.
    /// </remarks>
    public T GetRangeInValue(int n)
    {
        if (n < 0 || n >= _range.Count)
            throw new ArgumentOutOfRangeException("�ش� �Ű������� �ش��ϴ� �ε��� ���� �����ϴ�.");

        return _range[n];
    }
}
