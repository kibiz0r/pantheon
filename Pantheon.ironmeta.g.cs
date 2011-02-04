//
// IronMeta Pantheon Parser; Generated 2/4/2011 2:49:01 AM UTC
//

using System;
using System.Collections.Generic;
using System.Linq;
using IronMeta.Matcher;
using System.Linq.Expressions;

namespace Pantheon
{

    using _Pantheon_Inputs = IEnumerable<char>;
    using _Pantheon_Results = IEnumerable<Expression>;
    using _Pantheon_Args = IEnumerable<_Pantheon_Item>;
    using _Pantheon_Rule = System.Action<int, IEnumerable<_Pantheon_Item>>;
    using _Pantheon_Base = IronMeta.Matcher.Matcher<char, Expression, _Pantheon_Item>;


    public class _Pantheon_Item : IronMeta.Matcher.MatchItem<char, Expression, _Pantheon_Item>
    {
        public _Pantheon_Item() { }
        public _Pantheon_Item(char input) : base(input) { }
        public _Pantheon_Item(char input, Expression result) : base(input, result) { }
        public _Pantheon_Item(_Pantheon_Inputs inputs) : base(inputs) { }
        public _Pantheon_Item(_Pantheon_Inputs inputs, _Pantheon_Results results) : base(inputs, results) { }
        public _Pantheon_Item(int start, int next, _Pantheon_Inputs inputs, _Pantheon_Results results, bool relative) : base(start, next, inputs, results, relative) { }
        public _Pantheon_Item(int start, _Pantheon_Inputs inputs) : base(start, start, inputs, Enumerable.Empty<Expression>(), true) { }
        public _Pantheon_Item(_Pantheon_Rule production) : base(production) { }

        public static implicit operator List<char>(_Pantheon_Item item) { return item != null ? item.Inputs.ToList() : new List<char>(); }
        public static implicit operator char(_Pantheon_Item item) { return item != null ? item.Inputs.LastOrDefault() : default(char); }
        public static implicit operator List<Expression>(_Pantheon_Item item) { return item != null ? item.Results.ToList() : new List<Expression>(); }
        public static implicit operator Expression(_Pantheon_Item item) { return item != null ? item.Results.LastOrDefault() : default(Expression); }
    }

    public partial class Pantheon : IronMeta.Matcher.CharMatcher<Expression, _Pantheon_Item>
    {
        public Pantheon(IEnumerable<char> inputs)
            : base(inputs)
        { }


        public void Terminal(int _index, _Pantheon_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // OR 1
            int _start_i1 = _index;

            // OR 2
            int _start_i2 = _index;

            // NOT 3
            int _start_i3 = _index;

            // ANY
            _ParseAny(ref _index);

            // NOT 3
            var _r3 = _results.Pop();
            _results.Push( _r3 == null ? new _Pantheon_Item(_start_i3, _input_enumerable) : null);
            _index = _start_i3;
            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i2; } else goto label2;

            // CALLORVAR Whitespace
            _Pantheon_Item _r5;

            _r5 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r5 != null) _index = _r5.NextIndex;

        label2: // OR
            int _dummy_i2 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i1; } else goto label1;

            // CALLORVAR Operator
            _Pantheon_Item _r6;

            _r6 = _MemoCall("Operator", _index, Operator, null);

            if (_r6 != null) _index = _r6.NextIndex;

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // LITERAL "Terminal"
            _ParseLiteralString(ref _index, "Terminal");

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void Digit(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item n = null;

            // COND 0
            int _start_i0 = _index;

            // ANY
            _ParseAny(ref _index);

            // BIND n
            n = _results.Peek();

            // COND
            if (!(n >= '0' && n <= '9')) { _results.Pop(); _results.Push(null); _index = _start_i0; }
        }


        public void Number(int _index, _Pantheon_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // CALLORVAR NumberWithDecimal
            _Pantheon_Item _r1;

            _r1 = _MemoCall("NumberWithDecimal", _index, NumberWithDecimal, null);

            if (_r1 != null) _index = _r1.NextIndex;

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // CALLORVAR WholeNumber
            _Pantheon_Item _r2;

            _r2 = _MemoCall("WholeNumber", _index, WholeNumber, null);

            if (_r2 != null) _index = _r2.NextIndex;

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void WholeNumber(int _index, _Pantheon_Args _args)
        {

            // AND 0
            int _start_i0 = _index;

            // LITERAL '-'
            _ParseLiteralChar(ref _index, '-');

            // QUES
            if (_results.Peek() == null) { _results.Pop(); _results.Push(new _Pantheon_Item(_index, _input_enumerable)); }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label0; }

            // PLUS 3
            int _start_i3 = _index;
            var _res3 = Enumerable.Empty<Expression>();
        label3:

            // CALLORVAR Digit
            _Pantheon_Item _r4;

            _r4 = _MemoCall("Digit", _index, Digit, null);

            if (_r4 != null) _index = _r4.NextIndex;

            // PLUS 3
            var _r3 = _results.Pop();
            if (_r3 != null)
            {
                _res3 = _res3.Concat(_r3.Results);
                goto label3;
            }
            else
            {
                if (_index > _start_i3)
                    _results.Push(new _Pantheon_Item(_start_i3, _index, _input_enumerable, _res3.Where(_NON_NULL), true));
                else
                    _results.Push(null);
            }

        label0: // AND
            var _r0_2 = _results.Pop();
            var _r0_1 = _results.Pop();

            if (_r0_1 != null && _r0_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i0, _index, _input_enumerable, _r0_1.Results.Concat(_r0_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i0;
            }

        }


        public void NumberWithDecimal(int _index, _Pantheon_Args _args)
        {

            // AND 0
            int _start_i0 = _index;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // LITERAL '-'
            _ParseLiteralChar(ref _index, '-');

            // QUES
            if (_results.Peek() == null) { _results.Pop(); _results.Push(new _Pantheon_Item(_index, _input_enumerable)); }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label2; }

            // STAR 5
            int _start_i5 = _index;
            var _res5 = Enumerable.Empty<Expression>();
        label5:

            // CALLORVAR Digit
            _Pantheon_Item _r6;

            _r6 = _MemoCall("Digit", _index, Digit, null);

            if (_r6 != null) _index = _r6.NextIndex;

            // STAR 5
            var _r5 = _results.Pop();
            if (_r5 != null)
            {
                _res5 = _res5.Concat(_r5.Results);
                goto label5;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i5, _index, _input_enumerable, _res5.Where(_NON_NULL), true));
            }

        label2: // AND
            var _r2_2 = _results.Pop();
            var _r2_1 = _results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i2, _index, _input_enumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label1; }

            // LITERAL '.'
            _ParseLiteralChar(ref _index, '.');

        label1: // AND
            var _r1_2 = _results.Pop();
            var _r1_1 = _results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i1, _index, _input_enumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i1;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label0; }

            // PLUS 8
            int _start_i8 = _index;
            var _res8 = Enumerable.Empty<Expression>();
        label8:

            // CALLORVAR Digit
            _Pantheon_Item _r9;

            _r9 = _MemoCall("Digit", _index, Digit, null);

            if (_r9 != null) _index = _r9.NextIndex;

            // PLUS 8
            var _r8 = _results.Pop();
            if (_r8 != null)
            {
                _res8 = _res8.Concat(_r8.Results);
                goto label8;
            }
            else
            {
                if (_index > _start_i8)
                    _results.Push(new _Pantheon_Item(_start_i8, _index, _input_enumerable, _res8.Where(_NON_NULL), true));
                else
                    _results.Push(null);
            }

        label0: // AND
            var _r0_2 = _results.Pop();
            var _r0_1 = _results.Pop();

            if (_r0_1 != null && _r0_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i0, _index, _input_enumerable, _r0_1.Results.Concat(_r0_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i0;
            }

        }


        public void Character(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item c = null;

            // COND 0
            int _start_i0 = _index;

            // ANY
            _ParseAny(ref _index);

            // BIND c
            c = _results.Peek();

            // COND
            if (!(c >= 'A' && c <= 'z')) { _results.Pop(); _results.Push(null); _index = _start_i0; }
        }


        public void Whitespace(int _index, _Pantheon_Args _args)
        {

            // LITERAL ' '
            _ParseLiteralChar(ref _index, ' ');

        }


        public void Plus(int _index, _Pantheon_Args _args)
        {

            // LITERAL '+'
            _ParseLiteralChar(ref _index, '+');

        }


        public void Asterisk(int _index, _Pantheon_Args _args)
        {

            // LITERAL '*'
            _ParseLiteralChar(ref _index, '*');

        }


        public void Operator(int _index, _Pantheon_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // CALLORVAR Plus
            _Pantheon_Item _r1;

            _r1 = _MemoCall("Plus", _index, Plus, null);

            if (_r1 != null) _index = _r1.NextIndex;

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // CALLORVAR Asterisk
            _Pantheon_Item _r2;

            _r2 = _MemoCall("Asterisk", _index, Asterisk, null);

            if (_r2 != null) _index = _r2.NextIndex;

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void LongSuffix(int _index, _Pantheon_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // LITERAL 'l'
            _ParseLiteralChar(ref _index, 'l');

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // LITERAL 'L'
            _ParseLiteralChar(ref _index, 'L');

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void FloatSuffix(int _index, _Pantheon_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // LITERAL 'f'
            _ParseLiteralChar(ref _index, 'f');

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // LITERAL 'F'
            _ParseLiteralChar(ref _index, 'F');

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void Integer(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item n = null;

            // AND 1
            int _start_i1 = _index;

            // CALLORVAR WholeNumber
            _Pantheon_Item _r3;

            _r3 = _MemoCall("WholeNumber", _index, WholeNumber, null);

            if (_r3 != null) _index = _r3.NextIndex;

            // BIND n
            n = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label1; }

            // LOOK 4
            int _start_i4 = _index;

            // CALLORVAR Terminal
            _Pantheon_Item _r5;

            _r5 = _MemoCall("Terminal", _index, Terminal, null);

            if (_r5 != null) _index = _r5.NextIndex;

            // LOOK 4
            var _r4 = _results.Pop();
            _results.Push( _r4 != null ? new _Pantheon_Item(_start_i4, _input_enumerable) : null );
            _index = _start_i4;

        label1: // AND
            var _r1_2 = _results.Pop();
            var _r1_1 = _results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i1, _index, _input_enumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _results.Peek();
            if (_r0 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r0.StartIndex, _r0.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Constant(int.Parse(n.Text())); }, _r0), true) );
            }

        }


        public void Long(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item n = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // CALLORVAR WholeNumber
            _Pantheon_Item _r4;

            _r4 = _MemoCall("WholeNumber", _index, WholeNumber, null);

            if (_r4 != null) _index = _r4.NextIndex;

            // BIND n
            n = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label2; }

            // CALLORVAR LongSuffix
            _Pantheon_Item _r5;

            _r5 = _MemoCall("LongSuffix", _index, LongSuffix, null);

            if (_r5 != null) _index = _r5.NextIndex;

        label2: // AND
            var _r2_2 = _results.Pop();
            var _r2_1 = _results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i2, _index, _input_enumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label1; }

            // LOOK 6
            int _start_i6 = _index;

            // CALLORVAR Terminal
            _Pantheon_Item _r7;

            _r7 = _MemoCall("Terminal", _index, Terminal, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // LOOK 6
            var _r6 = _results.Pop();
            _results.Push( _r6 != null ? new _Pantheon_Item(_start_i6, _input_enumerable) : null );
            _index = _start_i6;

        label1: // AND
            var _r1_2 = _results.Pop();
            var _r1_1 = _results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i1, _index, _input_enumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _results.Peek();
            if (_r0 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r0.StartIndex, _r0.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Constant(long.Parse(n.Text())); }, _r0), true) );
            }

        }


        public void Float(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item n = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // CALLORVAR Number
            _Pantheon_Item _r4;

            _r4 = _MemoCall("Number", _index, Number, null);

            if (_r4 != null) _index = _r4.NextIndex;

            // BIND n
            n = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label2; }

            // CALLORVAR FloatSuffix
            _Pantheon_Item _r5;

            _r5 = _MemoCall("FloatSuffix", _index, FloatSuffix, null);

            if (_r5 != null) _index = _r5.NextIndex;

        label2: // AND
            var _r2_2 = _results.Pop();
            var _r2_1 = _results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i2, _index, _input_enumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label1; }

            // LOOK 6
            int _start_i6 = _index;

            // CALLORVAR Terminal
            _Pantheon_Item _r7;

            _r7 = _MemoCall("Terminal", _index, Terminal, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // LOOK 6
            var _r6 = _results.Pop();
            _results.Push( _r6 != null ? new _Pantheon_Item(_start_i6, _input_enumerable) : null );
            _index = _start_i6;

        label1: // AND
            var _r1_2 = _results.Pop();
            var _r1_1 = _results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i1, _index, _input_enumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _results.Peek();
            if (_r0 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r0.StartIndex, _r0.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Constant(float.Parse(n.Text())); }, _r0), true) );
            }

        }


        public void Double(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item n = null;

            // AND 1
            int _start_i1 = _index;

            // CALLORVAR NumberWithDecimal
            _Pantheon_Item _r3;

            _r3 = _MemoCall("NumberWithDecimal", _index, NumberWithDecimal, null);

            if (_r3 != null) _index = _r3.NextIndex;

            // BIND n
            n = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label1; }

            // LOOK 4
            int _start_i4 = _index;

            // CALLORVAR Terminal
            _Pantheon_Item _r5;

            _r5 = _MemoCall("Terminal", _index, Terminal, null);

            if (_r5 != null) _index = _r5.NextIndex;

            // LOOK 4
            var _r4 = _results.Pop();
            _results.Push( _r4 != null ? new _Pantheon_Item(_start_i4, _input_enumerable) : null );
            _index = _start_i4;

        label1: // AND
            var _r1_2 = _results.Pop();
            var _r1_1 = _results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i1, _index, _input_enumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _results.Peek();
            if (_r0 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r0.StartIndex, _r0.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Constant(double.Parse(n.Text())); }, _r0), true) );
            }

        }


        public void NumericLiteral(int _index, _Pantheon_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // OR 1
            int _start_i1 = _index;

            // OR 2
            int _start_i2 = _index;

            // CALLORVAR Integer
            _Pantheon_Item _r3;

            _r3 = _MemoCall("Integer", _index, Integer, null);

            if (_r3 != null) _index = _r3.NextIndex;

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i2; } else goto label2;

            // CALLORVAR Long
            _Pantheon_Item _r4;

            _r4 = _MemoCall("Long", _index, Long, null);

            if (_r4 != null) _index = _r4.NextIndex;

        label2: // OR
            int _dummy_i2 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i1; } else goto label1;

            // CALLORVAR Float
            _Pantheon_Item _r5;

            _r5 = _MemoCall("Float", _index, Float, null);

            if (_r5 != null) _index = _r5.NextIndex;

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // CALLORVAR Double
            _Pantheon_Item _r6;

            _r6 = _MemoCall("Double", _index, Double, null);

            if (_r6 != null) _index = _r6.NextIndex;

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void DaysSuffix(int _index, _Pantheon_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // LITERAL 'd'
            _ParseLiteralChar(ref _index, 'd');

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // LITERAL 'D'
            _ParseLiteralChar(ref _index, 'D');

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void MinutesSuffix(int _index, _Pantheon_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // LITERAL 'm'
            _ParseLiteralChar(ref _index, 'm');

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // LITERAL 'M'
            _ParseLiteralChar(ref _index, 'M');

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void SecondsSuffix(int _index, _Pantheon_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // LITERAL 's'
            _ParseLiteralChar(ref _index, 's');

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // LITERAL 'S'
            _ParseLiteralChar(ref _index, 'S');

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void MillisecondsSuffix(int _index, _Pantheon_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // LITERAL "ms"
            _ParseLiteralString(ref _index, "ms");

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // LITERAL "MS"
            _ParseLiteralString(ref _index, "MS");

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void Days(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item n = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // CALLORVAR Number
            _Pantheon_Item _r4;

            _r4 = _MemoCall("Number", _index, Number, null);

            if (_r4 != null) _index = _r4.NextIndex;

            // BIND n
            n = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label2; }

            // CALLORVAR DaysSuffix
            _Pantheon_Item _r5;

            _r5 = _MemoCall("DaysSuffix", _index, DaysSuffix, null);

            if (_r5 != null) _index = _r5.NextIndex;

        label2: // AND
            var _r2_2 = _results.Pop();
            var _r2_1 = _results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i2, _index, _input_enumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label1; }

            // LOOK 6
            int _start_i6 = _index;

            // CALLORVAR Terminal
            _Pantheon_Item _r7;

            _r7 = _MemoCall("Terminal", _index, Terminal, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // LOOK 6
            var _r6 = _results.Pop();
            _results.Push( _r6 != null ? new _Pantheon_Item(_start_i6, _input_enumerable) : null );
            _index = _start_i6;

        label1: // AND
            var _r1_2 = _results.Pop();
            var _r1_1 = _results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i1, _index, _input_enumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _results.Peek();
            if (_r0 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r0.StartIndex, _r0.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Constant(TimeSpan.FromDays(double.Parse(n.Text()))); }, _r0), true) );
            }

        }


        public void Minutes(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item n = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // CALLORVAR Number
            _Pantheon_Item _r4;

            _r4 = _MemoCall("Number", _index, Number, null);

            if (_r4 != null) _index = _r4.NextIndex;

            // BIND n
            n = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label2; }

            // CALLORVAR MinutesSuffix
            _Pantheon_Item _r5;

            _r5 = _MemoCall("MinutesSuffix", _index, MinutesSuffix, null);

            if (_r5 != null) _index = _r5.NextIndex;

        label2: // AND
            var _r2_2 = _results.Pop();
            var _r2_1 = _results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i2, _index, _input_enumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label1; }

            // LOOK 6
            int _start_i6 = _index;

            // CALLORVAR Terminal
            _Pantheon_Item _r7;

            _r7 = _MemoCall("Terminal", _index, Terminal, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // LOOK 6
            var _r6 = _results.Pop();
            _results.Push( _r6 != null ? new _Pantheon_Item(_start_i6, _input_enumerable) : null );
            _index = _start_i6;

        label1: // AND
            var _r1_2 = _results.Pop();
            var _r1_1 = _results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i1, _index, _input_enumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _results.Peek();
            if (_r0 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r0.StartIndex, _r0.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Constant(TimeSpan.FromMinutes(double.Parse(n.Text()))); }, _r0), true) );
            }

        }


        public void Seconds(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item n = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // CALLORVAR Number
            _Pantheon_Item _r4;

            _r4 = _MemoCall("Number", _index, Number, null);

            if (_r4 != null) _index = _r4.NextIndex;

            // BIND n
            n = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label2; }

            // CALLORVAR SecondsSuffix
            _Pantheon_Item _r5;

            _r5 = _MemoCall("SecondsSuffix", _index, SecondsSuffix, null);

            if (_r5 != null) _index = _r5.NextIndex;

        label2: // AND
            var _r2_2 = _results.Pop();
            var _r2_1 = _results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i2, _index, _input_enumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label1; }

            // LOOK 6
            int _start_i6 = _index;

            // CALLORVAR Terminal
            _Pantheon_Item _r7;

            _r7 = _MemoCall("Terminal", _index, Terminal, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // LOOK 6
            var _r6 = _results.Pop();
            _results.Push( _r6 != null ? new _Pantheon_Item(_start_i6, _input_enumerable) : null );
            _index = _start_i6;

        label1: // AND
            var _r1_2 = _results.Pop();
            var _r1_1 = _results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i1, _index, _input_enumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _results.Peek();
            if (_r0 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r0.StartIndex, _r0.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Constant(TimeSpan.FromSeconds(double.Parse(n.Text()))); }, _r0), true) );
            }

        }


        public void Milliseconds(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item n = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // CALLORVAR Number
            _Pantheon_Item _r4;

            _r4 = _MemoCall("Number", _index, Number, null);

            if (_r4 != null) _index = _r4.NextIndex;

            // BIND n
            n = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label2; }

            // CALLORVAR MillisecondsSuffix
            _Pantheon_Item _r5;

            _r5 = _MemoCall("MillisecondsSuffix", _index, MillisecondsSuffix, null);

            if (_r5 != null) _index = _r5.NextIndex;

        label2: // AND
            var _r2_2 = _results.Pop();
            var _r2_1 = _results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i2, _index, _input_enumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label1; }

            // LOOK 6
            int _start_i6 = _index;

            // CALLORVAR Terminal
            _Pantheon_Item _r7;

            _r7 = _MemoCall("Terminal", _index, Terminal, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // LOOK 6
            var _r6 = _results.Pop();
            _results.Push( _r6 != null ? new _Pantheon_Item(_start_i6, _input_enumerable) : null );
            _index = _start_i6;

        label1: // AND
            var _r1_2 = _results.Pop();
            var _r1_1 = _results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i1, _index, _input_enumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _results.Peek();
            if (_r0 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r0.StartIndex, _r0.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Constant(TimeSpan.FromMilliseconds(double.Parse(n.Text()))); }, _r0), true) );
            }

        }


        public void TimeSpanLiteral(int _index, _Pantheon_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // OR 1
            int _start_i1 = _index;

            // OR 2
            int _start_i2 = _index;

            // CALLORVAR Days
            _Pantheon_Item _r3;

            _r3 = _MemoCall("Days", _index, Days, null);

            if (_r3 != null) _index = _r3.NextIndex;

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i2; } else goto label2;

            // CALLORVAR Minutes
            _Pantheon_Item _r4;

            _r4 = _MemoCall("Minutes", _index, Minutes, null);

            if (_r4 != null) _index = _r4.NextIndex;

        label2: // OR
            int _dummy_i2 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i1; } else goto label1;

            // CALLORVAR Seconds
            _Pantheon_Item _r5;

            _r5 = _MemoCall("Seconds", _index, Seconds, null);

            if (_r5 != null) _index = _r5.NextIndex;

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // CALLORVAR Milliseconds
            _Pantheon_Item _r6;

            _r6 = _MemoCall("Milliseconds", _index, Milliseconds, null);

            if (_r6 != null) _index = _r6.NextIndex;

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void Literal(int _index, _Pantheon_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // CALLORVAR NumericLiteral
            _Pantheon_Item _r1;

            _r1 = _MemoCall("NumericLiteral", _index, NumericLiteral, null);

            if (_r1 != null) _index = _r1.NextIndex;

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // CALLORVAR TimeSpanLiteral
            _Pantheon_Item _r2;

            _r2 = _MemoCall("TimeSpanLiteral", _index, TimeSpanLiteral, null);

            if (_r2 != null) _index = _r2.NextIndex;

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void IntegerExpr(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item expr = null;

            // COND 0
            int _start_i0 = _index;

            // CALLORVAR Expr
            _Pantheon_Item _r2;

            _r2 = _MemoCall("Expr", _index, Expr, null);

            if (_r2 != null) _index = _r2.NextIndex;

            // BIND expr
            expr = _results.Peek();

            // COND
            if (!(expr != null && expr.IsExpressionOf<int>())) { _results.Pop(); _results.Push(null); _index = _start_i0; }
        }


        public void FloatExpr(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item expr = null;

            // OR 0
            int _start_i0 = _index;

            // CALLORVAR IntegerExpr
            _Pantheon_Item _r3;

            _r3 = _MemoCall("IntegerExpr", _index, IntegerExpr, null);

            if (_r3 != null) _index = _r3.NextIndex;

            // BIND expr
            expr = _results.Peek();

            // ACT
            var _r1 = _results.Peek();
            if (_r1 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r1.StartIndex, _r1.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Convert(expr, typeof(float)); }, _r1), true) );
            }

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // COND 4
            int _start_i4 = _index;

            // CALLORVAR Expr
            _Pantheon_Item _r6;

            _r6 = _MemoCall("Expr", _index, Expr, null);

            if (_r6 != null) _index = _r6.NextIndex;

            // BIND expr
            expr = _results.Peek();

            // COND
            if (!(expr != null && expr.IsExpressionOf<float>())) { _results.Pop(); _results.Push(null); _index = _start_i4; }
        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void DoubleExpr(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item expr = null;

            // OR 0
            int _start_i0 = _index;

            // OR 3
            int _start_i3 = _index;

            // CALLORVAR IntegerExpr
            _Pantheon_Item _r4;

            _r4 = _MemoCall("IntegerExpr", _index, IntegerExpr, null);

            if (_r4 != null) _index = _r4.NextIndex;

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i3; } else goto label3;

            // CALLORVAR FloatExpr
            _Pantheon_Item _r5;

            _r5 = _MemoCall("FloatExpr", _index, FloatExpr, null);

            if (_r5 != null) _index = _r5.NextIndex;

        label3: // OR
            int _dummy_i3 = _index; // no-op for label

            // BIND expr
            expr = _results.Peek();

            // ACT
            var _r1 = _results.Peek();
            if (_r1 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r1.StartIndex, _r1.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Convert(expr, typeof(double)); }, _r1), true) );
            }

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // COND 6
            int _start_i6 = _index;

            // CALLORVAR Expr
            _Pantheon_Item _r8;

            _r8 = _MemoCall("Expr", _index, Expr, null);

            if (_r8 != null) _index = _r8.NextIndex;

            // BIND expr
            expr = _results.Peek();

            // COND
            if (!(expr != null && expr.IsExpressionOf<double>())) { _results.Pop(); _results.Push(null); _index = _start_i6; }
        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void TimeSpanExpr(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item expr = null;

            // COND 0
            int _start_i0 = _index;

            // CALLORVAR Expr
            _Pantheon_Item _r2;

            _r2 = _MemoCall("Expr", _index, Expr, null);

            if (_r2 != null) _index = _r2.NextIndex;

            // BIND expr
            expr = _results.Peek();

            // COND
            if (!(expr != null && expr.IsExpressionOf<TimeSpan>())) { _results.Pop(); _results.Push(null); _index = _start_i0; }
        }


        public void Add(int _index, _Pantheon_Args _args)
        {

            int _arg_index = 0;
            int _arg_input_index = 0;

            _Pantheon_Item type = null;
            _Pantheon_Item left = null;
            _Pantheon_Item right = null;

            // OR 0
            int _start_i0 = _index;

            // ARGS 1
            _arg_index = 0;
            _arg_input_index = 0;

            // ANY
            _ParseAnyArgs(ref _arg_index, ref _arg_input_index, _args);

            // BIND type
            type = _arg_results.Peek();

            if (_arg_results.Pop() == null)
            {
                _results.Push(null);
                goto label1;
            }

            // AND 5
            int _start_i5 = _index;

            // AND 6
            int _start_i6 = _index;

            // AND 7
            int _start_i7 = _index;

            // AND 8
            int _start_i8 = _index;

            // CALLORVAR type
            _Pantheon_Item _r10;

            if (type.Production != null)
            {
                var _p10 = (System.Action<int, IEnumerable<_Pantheon_Item>>)(object)type.Production; // what type safety?
                _r10 = _MemoCall(type.Production.Method.Name, _index, _p10, null);
            }
            else
            {
                _r10 = _ParseLiteralObj(ref _index, type.Inputs);
            }

            if (_r10 != null) _index = _r10.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label8; }

            // STAR 11
            int _start_i11 = _index;
            var _res11 = Enumerable.Empty<Expression>();
        label11:

            // CALLORVAR Whitespace
            _Pantheon_Item _r12;

            _r12 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r12 != null) _index = _r12.NextIndex;

            // STAR 11
            var _r11 = _results.Pop();
            if (_r11 != null)
            {
                _res11 = _res11.Concat(_r11.Results);
                goto label11;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i11, _index, _input_enumerable, _res11.Where(_NON_NULL), true));
            }

        label8: // AND
            var _r8_2 = _results.Pop();
            var _r8_1 = _results.Pop();

            if (_r8_1 != null && _r8_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i8, _index, _input_enumerable, _r8_1.Results.Concat(_r8_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i8;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label7; }

            // CALLORVAR Plus
            _Pantheon_Item _r13;

            _r13 = _MemoCall("Plus", _index, Plus, null);

            if (_r13 != null) _index = _r13.NextIndex;

        label7: // AND
            var _r7_2 = _results.Pop();
            var _r7_1 = _results.Pop();

            if (_r7_1 != null && _r7_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i7, _index, _input_enumerable, _r7_1.Results.Concat(_r7_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i7;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label6; }

            // STAR 14
            int _start_i14 = _index;
            var _res14 = Enumerable.Empty<Expression>();
        label14:

            // CALLORVAR Whitespace
            _Pantheon_Item _r15;

            _r15 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r15 != null) _index = _r15.NextIndex;

            // STAR 14
            var _r14 = _results.Pop();
            if (_r14 != null)
            {
                _res14 = _res14.Concat(_r14.Results);
                goto label14;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i14, _index, _input_enumerable, _res14.Where(_NON_NULL), true));
            }

        label6: // AND
            var _r6_2 = _results.Pop();
            var _r6_1 = _results.Pop();

            if (_r6_1 != null && _r6_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i6, _index, _input_enumerable, _r6_1.Results.Concat(_r6_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i6;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label5; }

            // CALLORVAR type
            _Pantheon_Item _r17;

            if (type.Production != null)
            {
                var _p17 = (System.Action<int, IEnumerable<_Pantheon_Item>>)(object)type.Production; // what type safety?
                _r17 = _MemoCall(type.Production.Method.Name, _index, _p17, null);
            }
            else
            {
                _r17 = _ParseLiteralObj(ref _index, type.Inputs);
            }

            if (_r17 != null) _index = _r17.NextIndex;

            // BIND right
            right = _results.Peek();

        label5: // AND
            var _r5_2 = _results.Pop();
            var _r5_1 = _results.Pop();

            if (_r5_1 != null && _r5_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i5, _index, _input_enumerable, _r5_1.Results.Concat(_r5_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i5;
            }

            // ACT
            var _r4 = _results.Peek();
            if (_r4 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r4.StartIndex, _r4.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.AddChecked(left, right); }, _r4), true) );
            }

        label1: // ARGS 1
            _arg_input_index = _arg_index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // AND 19
            int _start_i19 = _index;

            // AND 20
            int _start_i20 = _index;

            // AND 21
            int _start_i21 = _index;

            // AND 22
            int _start_i22 = _index;

            // CALLORVAR Expr
            _Pantheon_Item _r24;

            _r24 = _MemoCall("Expr", _index, Expr, null);

            if (_r24 != null) _index = _r24.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label22; }

            // STAR 25
            int _start_i25 = _index;
            var _res25 = Enumerable.Empty<Expression>();
        label25:

            // CALLORVAR Whitespace
            _Pantheon_Item _r26;

            _r26 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r26 != null) _index = _r26.NextIndex;

            // STAR 25
            var _r25 = _results.Pop();
            if (_r25 != null)
            {
                _res25 = _res25.Concat(_r25.Results);
                goto label25;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i25, _index, _input_enumerable, _res25.Where(_NON_NULL), true));
            }

        label22: // AND
            var _r22_2 = _results.Pop();
            var _r22_1 = _results.Pop();

            if (_r22_1 != null && _r22_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i22, _index, _input_enumerable, _r22_1.Results.Concat(_r22_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i22;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label21; }

            // CALLORVAR Plus
            _Pantheon_Item _r27;

            _r27 = _MemoCall("Plus", _index, Plus, null);

            if (_r27 != null) _index = _r27.NextIndex;

        label21: // AND
            var _r21_2 = _results.Pop();
            var _r21_1 = _results.Pop();

            if (_r21_1 != null && _r21_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i21, _index, _input_enumerable, _r21_1.Results.Concat(_r21_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i21;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label20; }

            // STAR 28
            int _start_i28 = _index;
            var _res28 = Enumerable.Empty<Expression>();
        label28:

            // CALLORVAR Whitespace
            _Pantheon_Item _r29;

            _r29 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r29 != null) _index = _r29.NextIndex;

            // STAR 28
            var _r28 = _results.Pop();
            if (_r28 != null)
            {
                _res28 = _res28.Concat(_r28.Results);
                goto label28;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i28, _index, _input_enumerable, _res28.Where(_NON_NULL), true));
            }

        label20: // AND
            var _r20_2 = _results.Pop();
            var _r20_1 = _results.Pop();

            if (_r20_1 != null && _r20_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i20, _index, _input_enumerable, _r20_1.Results.Concat(_r20_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i20;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label19; }

            // COND 30
            int _start_i30 = _index;

            // CALLORVAR Expr
            _Pantheon_Item _r32;

            _r32 = _MemoCall("Expr", _index, Expr, null);

            if (_r32 != null) _index = _r32.NextIndex;

            // BIND right
            right = _results.Peek();

            // COND
            if (!(left.Expression().Type == right.Expression().Type)) { _results.Pop(); _results.Push(null); _index = _start_i30; }
        label19: // AND
            var _r19_2 = _results.Pop();
            var _r19_1 = _results.Pop();

            if (_r19_1 != null && _r19_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i19, _index, _input_enumerable, _r19_1.Results.Concat(_r19_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i19;
            }

            // ACT
            var _r18 = _results.Peek();
            if (_r18 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r18.StartIndex, _r18.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.AddChecked(left, right); }, _r18), true) );
            }

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void Multiply(int _index, _Pantheon_Args _args)
        {

            int _arg_index = 0;
            int _arg_input_index = 0;

            _Pantheon_Item type = null;
            _Pantheon_Item left = null;
            _Pantheon_Item right = null;

            // ARGS 0
            _arg_index = 0;
            _arg_input_index = 0;

            // ANY
            _ParseAnyArgs(ref _arg_index, ref _arg_input_index, _args);

            // BIND type
            type = _arg_results.Peek();

            if (_arg_results.Pop() == null)
            {
                _results.Push(null);
                goto label0;
            }

            // AND 4
            int _start_i4 = _index;

            // AND 5
            int _start_i5 = _index;

            // AND 6
            int _start_i6 = _index;

            // AND 7
            int _start_i7 = _index;

            // CALLORVAR type
            _Pantheon_Item _r9;

            if (type.Production != null)
            {
                var _p9 = (System.Action<int, IEnumerable<_Pantheon_Item>>)(object)type.Production; // what type safety?
                _r9 = _MemoCall(type.Production.Method.Name, _index, _p9, null);
            }
            else
            {
                _r9 = _ParseLiteralObj(ref _index, type.Inputs);
            }

            if (_r9 != null) _index = _r9.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label7; }

            // STAR 10
            int _start_i10 = _index;
            var _res10 = Enumerable.Empty<Expression>();
        label10:

            // CALLORVAR Whitespace
            _Pantheon_Item _r11;

            _r11 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r11 != null) _index = _r11.NextIndex;

            // STAR 10
            var _r10 = _results.Pop();
            if (_r10 != null)
            {
                _res10 = _res10.Concat(_r10.Results);
                goto label10;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i10, _index, _input_enumerable, _res10.Where(_NON_NULL), true));
            }

        label7: // AND
            var _r7_2 = _results.Pop();
            var _r7_1 = _results.Pop();

            if (_r7_1 != null && _r7_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i7, _index, _input_enumerable, _r7_1.Results.Concat(_r7_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i7;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label6; }

            // CALLORVAR Asterisk
            _Pantheon_Item _r12;

            _r12 = _MemoCall("Asterisk", _index, Asterisk, null);

            if (_r12 != null) _index = _r12.NextIndex;

        label6: // AND
            var _r6_2 = _results.Pop();
            var _r6_1 = _results.Pop();

            if (_r6_1 != null && _r6_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i6, _index, _input_enumerable, _r6_1.Results.Concat(_r6_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i6;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label5; }

            // STAR 13
            int _start_i13 = _index;
            var _res13 = Enumerable.Empty<Expression>();
        label13:

            // CALLORVAR Whitespace
            _Pantheon_Item _r14;

            _r14 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r14 != null) _index = _r14.NextIndex;

            // STAR 13
            var _r13 = _results.Pop();
            if (_r13 != null)
            {
                _res13 = _res13.Concat(_r13.Results);
                goto label13;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i13, _index, _input_enumerable, _res13.Where(_NON_NULL), true));
            }

        label5: // AND
            var _r5_2 = _results.Pop();
            var _r5_1 = _results.Pop();

            if (_r5_1 != null && _r5_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i5, _index, _input_enumerable, _r5_1.Results.Concat(_r5_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i5;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label4; }

            // CALLORVAR type
            _Pantheon_Item _r16;

            if (type.Production != null)
            {
                var _p16 = (System.Action<int, IEnumerable<_Pantheon_Item>>)(object)type.Production; // what type safety?
                _r16 = _MemoCall(type.Production.Method.Name, _index, _p16, null);
            }
            else
            {
                _r16 = _ParseLiteralObj(ref _index, type.Inputs);
            }

            if (_r16 != null) _index = _r16.NextIndex;

            // BIND right
            right = _results.Peek();

        label4: // AND
            var _r4_2 = _results.Pop();
            var _r4_1 = _results.Pop();

            if (_r4_1 != null && _r4_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i4, _index, _input_enumerable, _r4_1.Results.Concat(_r4_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i4;
            }

            // ACT
            var _r3 = _results.Peek();
            if (_r3 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r3.StartIndex, _r3.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.MultiplyChecked(left, right); }, _r3), true) );
            }

        label0: // ARGS 0
            _arg_input_index = _arg_index; // no-op for label

        }


        public void Expr(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item expr = null;

            // OR 1
            int _start_i1 = _index;

            // OR 2
            int _start_i2 = _index;

            // OR 3
            int _start_i3 = _index;

            // OR 4
            int _start_i4 = _index;

            // OR 5
            int _start_i5 = _index;

            // CALL Multiply
            var _start_i6 = _index;
            _Pantheon_Item _r6;

            _r6 = _MemoCall("Multiply", _index, Multiply, new _Pantheon_Item[] { new _Pantheon_Item(IntegerExpr) });

            if (_r6 != null) _index = _r6.NextIndex;

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i5; } else goto label5;

            // CALL Add
            var _start_i7 = _index;
            _Pantheon_Item _r7;

            _r7 = _MemoCall("Add", _index, Add, new _Pantheon_Item[] { new _Pantheon_Item(IntegerExpr) });

            if (_r7 != null) _index = _r7.NextIndex;

        label5: // OR
            int _dummy_i5 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i4; } else goto label4;

            // CALL Add
            var _start_i8 = _index;
            _Pantheon_Item _r8;

            _r8 = _MemoCall("Add", _index, Add, new _Pantheon_Item[] { new _Pantheon_Item(FloatExpr) });

            if (_r8 != null) _index = _r8.NextIndex;

        label4: // OR
            int _dummy_i4 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i3; } else goto label3;

            // CALL Add
            var _start_i9 = _index;
            _Pantheon_Item _r9;

            _r9 = _MemoCall("Add", _index, Add, new _Pantheon_Item[] { new _Pantheon_Item(DoubleExpr) });

            if (_r9 != null) _index = _r9.NextIndex;

        label3: // OR
            int _dummy_i3 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i2; } else goto label2;

            // CALL Add
            var _start_i10 = _index;
            _Pantheon_Item _r10;

            _r10 = _MemoCall("Add", _index, Add, new _Pantheon_Item[] { new _Pantheon_Item(TimeSpanExpr) });

            if (_r10 != null) _index = _r10.NextIndex;

        label2: // OR
            int _dummy_i2 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i1; } else goto label1;

            // CALLORVAR Literal
            _Pantheon_Item _r11;

            _r11 = _MemoCall("Literal", _index, Literal, null);

            if (_r11 != null) _index = _r11.NextIndex;

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // BIND expr
            expr = _results.Peek();

        }

    } // class Pantheon

} // namespace Pantheon

