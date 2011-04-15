//
// IronMeta Pantheon Parser; Generated 2/6/2011 7:48:15 AM UTC
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


        public void IntegerLiteral(int _index, _Pantheon_Args _args)
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


        public void LongLiteral(int _index, _Pantheon_Args _args)
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


        public void FloatLiteral(int _index, _Pantheon_Args _args)
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


        public void DoubleLiteral(int _index, _Pantheon_Args _args)
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

            // CALLORVAR IntegerLiteral
            _Pantheon_Item _r3;

            _r3 = _MemoCall("IntegerLiteral", _index, IntegerLiteral, null);

            if (_r3 != null) _index = _r3.NextIndex;

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i2; } else goto label2;

            // CALLORVAR LongLiteral
            _Pantheon_Item _r4;

            _r4 = _MemoCall("LongLiteral", _index, LongLiteral, null);

            if (_r4 != null) _index = _r4.NextIndex;

        label2: // OR
            int _dummy_i2 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i1; } else goto label1;

            // CALLORVAR FloatLiteral
            _Pantheon_Item _r5;

            _r5 = _MemoCall("FloatLiteral", _index, FloatLiteral, null);

            if (_r5 != null) _index = _r5.NextIndex;

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // CALLORVAR DoubleLiteral
            _Pantheon_Item _r6;

            _r6 = _MemoCall("DoubleLiteral", _index, DoubleLiteral, null);

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


        public void DaysLiteral(int _index, _Pantheon_Args _args)
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


        public void MinutesLiteral(int _index, _Pantheon_Args _args)
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


        public void SecondsLiteral(int _index, _Pantheon_Args _args)
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


        public void MillisecondsLiteral(int _index, _Pantheon_Args _args)
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

            // CALLORVAR DaysLiteral
            _Pantheon_Item _r3;

            _r3 = _MemoCall("DaysLiteral", _index, DaysLiteral, null);

            if (_r3 != null) _index = _r3.NextIndex;

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i2; } else goto label2;

            // CALLORVAR MinutesLiteral
            _Pantheon_Item _r4;

            _r4 = _MemoCall("MinutesLiteral", _index, MinutesLiteral, null);

            if (_r4 != null) _index = _r4.NextIndex;

        label2: // OR
            int _dummy_i2 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i1; } else goto label1;

            // CALLORVAR SecondsLiteral
            _Pantheon_Item _r5;

            _r5 = _MemoCall("SecondsLiteral", _index, SecondsLiteral, null);

            if (_r5 != null) _index = _r5.NextIndex;

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // CALLORVAR MillisecondsLiteral
            _Pantheon_Item _r6;

            _r6 = _MemoCall("MillisecondsLiteral", _index, MillisecondsLiteral, null);

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


        public void IntegerValue(int _index, _Pantheon_Args _args)
        {

            // CALLORVAR IntegerLiteral
            _Pantheon_Item _r0;

            _r0 = _MemoCall("IntegerLiteral", _index, IntegerLiteral, null);

            if (_r0 != null) _index = _r0.NextIndex;

        }


        public void LongValue(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item lit = null;

            // OR 0
            int _start_i0 = _index;

            // CALLORVAR LongLiteral
            _Pantheon_Item _r1;

            _r1 = _MemoCall("LongLiteral", _index, LongLiteral, null);

            if (_r1 != null) _index = _r1.NextIndex;

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // CALLORVAR IntegerLiteral
            _Pantheon_Item _r4;

            _r4 = _MemoCall("IntegerLiteral", _index, IntegerLiteral, null);

            if (_r4 != null) _index = _r4.NextIndex;

            // BIND lit
            lit = _results.Peek();

            // ACT
            var _r2 = _results.Peek();
            if (_r2 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r2.StartIndex, _r2.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Convert(lit, typeof(long)); }, _r2), true) );
            }

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void FloatValue(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item lit = null;

            // OR 0
            int _start_i0 = _index;

            // CALLORVAR FloatLiteral
            _Pantheon_Item _r1;

            _r1 = _MemoCall("FloatLiteral", _index, FloatLiteral, null);

            if (_r1 != null) _index = _r1.NextIndex;

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // OR 4
            int _start_i4 = _index;

            // CALLORVAR IntegerLiteral
            _Pantheon_Item _r5;

            _r5 = _MemoCall("IntegerLiteral", _index, IntegerLiteral, null);

            if (_r5 != null) _index = _r5.NextIndex;

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i4; } else goto label4;

            // CALLORVAR LongLiteral
            _Pantheon_Item _r6;

            _r6 = _MemoCall("LongLiteral", _index, LongLiteral, null);

            if (_r6 != null) _index = _r6.NextIndex;

        label4: // OR
            int _dummy_i4 = _index; // no-op for label

            // BIND lit
            lit = _results.Peek();

            // ACT
            var _r2 = _results.Peek();
            if (_r2 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r2.StartIndex, _r2.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Convert(lit, typeof(float)); }, _r2), true) );
            }

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void DoubleValue(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item lit = null;

            // OR 0
            int _start_i0 = _index;

            // CALLORVAR DoubleLiteral
            _Pantheon_Item _r1;

            _r1 = _MemoCall("DoubleLiteral", _index, DoubleLiteral, null);

            if (_r1 != null) _index = _r1.NextIndex;

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // OR 4
            int _start_i4 = _index;

            // OR 5
            int _start_i5 = _index;

            // CALLORVAR IntegerLiteral
            _Pantheon_Item _r6;

            _r6 = _MemoCall("IntegerLiteral", _index, IntegerLiteral, null);

            if (_r6 != null) _index = _r6.NextIndex;

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i5; } else goto label5;

            // CALLORVAR LongLiteral
            _Pantheon_Item _r7;

            _r7 = _MemoCall("LongLiteral", _index, LongLiteral, null);

            if (_r7 != null) _index = _r7.NextIndex;

        label5: // OR
            int _dummy_i5 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i4; } else goto label4;

            // CALLORVAR FloatLiteral
            _Pantheon_Item _r8;

            _r8 = _MemoCall("FloatLiteral", _index, FloatLiteral, null);

            if (_r8 != null) _index = _r8.NextIndex;

        label4: // OR
            int _dummy_i4 = _index; // no-op for label

            // BIND lit
            lit = _results.Peek();

            // ACT
            var _r2 = _results.Peek();
            if (_r2 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r2.StartIndex, _r2.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Convert(lit, typeof(double)); }, _r2), true) );
            }

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void MultiplyInteger(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item left = null;
            _Pantheon_Item right = null;

            // OR 0
            int _start_i0 = _index;

            // AND 2
            int _start_i2 = _index;

            // AND 3
            int _start_i3 = _index;

            // AND 4
            int _start_i4 = _index;

            // AND 5
            int _start_i5 = _index;

            // CALLORVAR MultiplyInteger
            _Pantheon_Item _r7;

            _r7 = _MemoCall("MultiplyInteger", _index, MultiplyInteger, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label5; }

            // STAR 8
            int _start_i8 = _index;
            var _res8 = Enumerable.Empty<Expression>();
        label8:

            // CALLORVAR Whitespace
            _Pantheon_Item _r9;

            _r9 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r9 != null) _index = _r9.NextIndex;

            // STAR 8
            var _r8 = _results.Pop();
            if (_r8 != null)
            {
                _res8 = _res8.Concat(_r8.Results);
                goto label8;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i8, _index, _input_enumerable, _res8.Where(_NON_NULL), true));
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

            // CALLORVAR Asterisk
            _Pantheon_Item _r10;

            _r10 = _MemoCall("Asterisk", _index, Asterisk, null);

            if (_r10 != null) _index = _r10.NextIndex;

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

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label3; }

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

        label3: // AND
            var _r3_2 = _results.Pop();
            var _r3_1 = _results.Pop();

            if (_r3_1 != null && _r3_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i3, _index, _input_enumerable, _r3_1.Results.Concat(_r3_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i3;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label2; }

            // CALLORVAR IntegerValue
            _Pantheon_Item _r14;

            _r14 = _MemoCall("IntegerValue", _index, IntegerValue, null);

            if (_r14 != null) _index = _r14.NextIndex;

            // BIND right
            right = _results.Peek();

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

            // ACT
            var _r1 = _results.Peek();
            if (_r1 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r1.StartIndex, _r1.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Multiply(left, right); }, _r1), true) );
            }

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // CALLORVAR IntegerValue
            _Pantheon_Item _r15;

            _r15 = _MemoCall("IntegerValue", _index, IntegerValue, null);

            if (_r15 != null) _index = _r15.NextIndex;

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void MultiplyLong(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item left = null;
            _Pantheon_Item right = null;

            // OR 0
            int _start_i0 = _index;

            // AND 2
            int _start_i2 = _index;

            // AND 3
            int _start_i3 = _index;

            // AND 4
            int _start_i4 = _index;

            // AND 5
            int _start_i5 = _index;

            // CALLORVAR MultiplyLong
            _Pantheon_Item _r7;

            _r7 = _MemoCall("MultiplyLong", _index, MultiplyLong, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label5; }

            // STAR 8
            int _start_i8 = _index;
            var _res8 = Enumerable.Empty<Expression>();
        label8:

            // CALLORVAR Whitespace
            _Pantheon_Item _r9;

            _r9 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r9 != null) _index = _r9.NextIndex;

            // STAR 8
            var _r8 = _results.Pop();
            if (_r8 != null)
            {
                _res8 = _res8.Concat(_r8.Results);
                goto label8;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i8, _index, _input_enumerable, _res8.Where(_NON_NULL), true));
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

            // CALLORVAR Asterisk
            _Pantheon_Item _r10;

            _r10 = _MemoCall("Asterisk", _index, Asterisk, null);

            if (_r10 != null) _index = _r10.NextIndex;

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

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label3; }

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

        label3: // AND
            var _r3_2 = _results.Pop();
            var _r3_1 = _results.Pop();

            if (_r3_1 != null && _r3_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i3, _index, _input_enumerable, _r3_1.Results.Concat(_r3_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i3;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label2; }

            // CALLORVAR LongValue
            _Pantheon_Item _r14;

            _r14 = _MemoCall("LongValue", _index, LongValue, null);

            if (_r14 != null) _index = _r14.NextIndex;

            // BIND right
            right = _results.Peek();

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

            // ACT
            var _r1 = _results.Peek();
            if (_r1 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r1.StartIndex, _r1.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Multiply(left, right); }, _r1), true) );
            }

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // CALLORVAR LongValue
            _Pantheon_Item _r15;

            _r15 = _MemoCall("LongValue", _index, LongValue, null);

            if (_r15 != null) _index = _r15.NextIndex;

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void MultiplyFloat(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item left = null;
            _Pantheon_Item right = null;

            // OR 0
            int _start_i0 = _index;

            // AND 2
            int _start_i2 = _index;

            // AND 3
            int _start_i3 = _index;

            // AND 4
            int _start_i4 = _index;

            // AND 5
            int _start_i5 = _index;

            // CALLORVAR MultiplyFloat
            _Pantheon_Item _r7;

            _r7 = _MemoCall("MultiplyFloat", _index, MultiplyFloat, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label5; }

            // STAR 8
            int _start_i8 = _index;
            var _res8 = Enumerable.Empty<Expression>();
        label8:

            // CALLORVAR Whitespace
            _Pantheon_Item _r9;

            _r9 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r9 != null) _index = _r9.NextIndex;

            // STAR 8
            var _r8 = _results.Pop();
            if (_r8 != null)
            {
                _res8 = _res8.Concat(_r8.Results);
                goto label8;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i8, _index, _input_enumerable, _res8.Where(_NON_NULL), true));
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

            // CALLORVAR Asterisk
            _Pantheon_Item _r10;

            _r10 = _MemoCall("Asterisk", _index, Asterisk, null);

            if (_r10 != null) _index = _r10.NextIndex;

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

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label3; }

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

        label3: // AND
            var _r3_2 = _results.Pop();
            var _r3_1 = _results.Pop();

            if (_r3_1 != null && _r3_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i3, _index, _input_enumerable, _r3_1.Results.Concat(_r3_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i3;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label2; }

            // CALLORVAR FloatValue
            _Pantheon_Item _r14;

            _r14 = _MemoCall("FloatValue", _index, FloatValue, null);

            if (_r14 != null) _index = _r14.NextIndex;

            // BIND right
            right = _results.Peek();

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

            // ACT
            var _r1 = _results.Peek();
            if (_r1 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r1.StartIndex, _r1.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Multiply(left, right); }, _r1), true) );
            }

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // CALLORVAR FloatValue
            _Pantheon_Item _r15;

            _r15 = _MemoCall("FloatValue", _index, FloatValue, null);

            if (_r15 != null) _index = _r15.NextIndex;

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void MultiplyDouble(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item left = null;
            _Pantheon_Item right = null;

            // OR 0
            int _start_i0 = _index;

            // AND 2
            int _start_i2 = _index;

            // AND 3
            int _start_i3 = _index;

            // AND 4
            int _start_i4 = _index;

            // AND 5
            int _start_i5 = _index;

            // CALLORVAR MultiplyDouble
            _Pantheon_Item _r7;

            _r7 = _MemoCall("MultiplyDouble", _index, MultiplyDouble, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label5; }

            // STAR 8
            int _start_i8 = _index;
            var _res8 = Enumerable.Empty<Expression>();
        label8:

            // CALLORVAR Whitespace
            _Pantheon_Item _r9;

            _r9 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r9 != null) _index = _r9.NextIndex;

            // STAR 8
            var _r8 = _results.Pop();
            if (_r8 != null)
            {
                _res8 = _res8.Concat(_r8.Results);
                goto label8;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i8, _index, _input_enumerable, _res8.Where(_NON_NULL), true));
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

            // CALLORVAR Asterisk
            _Pantheon_Item _r10;

            _r10 = _MemoCall("Asterisk", _index, Asterisk, null);

            if (_r10 != null) _index = _r10.NextIndex;

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

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label3; }

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

        label3: // AND
            var _r3_2 = _results.Pop();
            var _r3_1 = _results.Pop();

            if (_r3_1 != null && _r3_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i3, _index, _input_enumerable, _r3_1.Results.Concat(_r3_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i3;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label2; }

            // CALLORVAR DoubleValue
            _Pantheon_Item _r14;

            _r14 = _MemoCall("DoubleValue", _index, DoubleValue, null);

            if (_r14 != null) _index = _r14.NextIndex;

            // BIND right
            right = _results.Peek();

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

            // ACT
            var _r1 = _results.Peek();
            if (_r1 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r1.StartIndex, _r1.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Multiply(left, right); }, _r1), true) );
            }

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // CALLORVAR DoubleValue
            _Pantheon_Item _r15;

            _r15 = _MemoCall("DoubleValue", _index, DoubleValue, null);

            if (_r15 != null) _index = _r15.NextIndex;

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

            // OR 3
            int _start_i3 = _index;

            // AND 5
            int _start_i5 = _index;

            // AND 6
            int _start_i6 = _index;

            // AND 7
            int _start_i7 = _index;

            // AND 8
            int _start_i8 = _index;

            // CALL Multiply
            var _start_i10 = _index;
            _Pantheon_Item _r10;

            _r10 = _MemoCall("Multiply", _index, Multiply, new _Pantheon_Item[] { type });

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

            // CALLORVAR Asterisk
            _Pantheon_Item _r13;

            _r13 = _MemoCall("Asterisk", _index, Asterisk, null);

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
                _results.Push( new _Pantheon_Item(_r4.StartIndex, _r4.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Multiply(left, right); }, _r4), true) );
            }

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i3; } else goto label3;

            // CALLORVAR type
            _Pantheon_Item _r18;

            if (type.Production != null)
            {
                var _p18 = (System.Action<int, IEnumerable<_Pantheon_Item>>)(object)type.Production; // what type safety?
                _r18 = _MemoCall(type.Production.Method.Name, _index, _p18, null);
            }
            else
            {
                _r18 = _ParseLiteralObj(ref _index, type.Inputs);
            }

            if (_r18 != null) _index = _r18.NextIndex;

        label3: // OR
            int _dummy_i3 = _index; // no-op for label

        label0: // ARGS 0
            _arg_input_index = _arg_index; // no-op for label

        }


        public void IntegerExpr(int _index, _Pantheon_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // OR 1
            int _start_i1 = _index;

            // CALLORVAR AddInteger
            _Pantheon_Item _r2;

            _r2 = _MemoCall("AddInteger", _index, AddInteger, null);

            if (_r2 != null) _index = _r2.NextIndex;

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i1; } else goto label1;

            // CALLORVAR MultiplyInteger
            _Pantheon_Item _r3;

            _r3 = _MemoCall("MultiplyInteger", _index, MultiplyInteger, null);

            if (_r3 != null) _index = _r3.NextIndex;

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // CALLORVAR IntegerValue
            _Pantheon_Item _r4;

            _r4 = _MemoCall("IntegerValue", _index, IntegerValue, null);

            if (_r4 != null) _index = _r4.NextIndex;

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void LongExpr(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item expr = null;

            // OR 0
            int _start_i0 = _index;

            // OR 1
            int _start_i1 = _index;

            // OR 2
            int _start_i2 = _index;

            // CALLORVAR IntegerExpr
            _Pantheon_Item _r5;

            _r5 = _MemoCall("IntegerExpr", _index, IntegerExpr, null);

            if (_r5 != null) _index = _r5.NextIndex;

            // BIND expr
            expr = _results.Peek();

            // ACT
            var _r3 = _results.Peek();
            if (_r3 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r3.StartIndex, _r3.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Convert(expr, typeof(int)); }, _r3), true) );
            }

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i2; } else goto label2;

            // CALLORVAR AddLong
            _Pantheon_Item _r6;

            _r6 = _MemoCall("AddLong", _index, AddLong, null);

            if (_r6 != null) _index = _r6.NextIndex;

        label2: // OR
            int _dummy_i2 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i1; } else goto label1;

            // CALLORVAR MultiplyLong
            _Pantheon_Item _r7;

            _r7 = _MemoCall("MultiplyLong", _index, MultiplyLong, null);

            if (_r7 != null) _index = _r7.NextIndex;

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // CALLORVAR LongValue
            _Pantheon_Item _r8;

            _r8 = _MemoCall("LongValue", _index, LongValue, null);

            if (_r8 != null) _index = _r8.NextIndex;

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void FloatExpr(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item expr = null;

            // OR 0
            int _start_i0 = _index;

            // OR 1
            int _start_i1 = _index;

            // OR 2
            int _start_i2 = _index;

            // OR 5
            int _start_i5 = _index;

            // CALLORVAR IntegerExpr
            _Pantheon_Item _r6;

            _r6 = _MemoCall("IntegerExpr", _index, IntegerExpr, null);

            if (_r6 != null) _index = _r6.NextIndex;

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i5; } else goto label5;

            // CALLORVAR LongExpr
            _Pantheon_Item _r7;

            _r7 = _MemoCall("LongExpr", _index, LongExpr, null);

            if (_r7 != null) _index = _r7.NextIndex;

        label5: // OR
            int _dummy_i5 = _index; // no-op for label

            // BIND expr
            expr = _results.Peek();

            // ACT
            var _r3 = _results.Peek();
            if (_r3 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r3.StartIndex, _r3.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Convert(expr, typeof(float)); }, _r3), true) );
            }

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i2; } else goto label2;

            // CALLORVAR AddFloat
            _Pantheon_Item _r8;

            _r8 = _MemoCall("AddFloat", _index, AddFloat, null);

            if (_r8 != null) _index = _r8.NextIndex;

        label2: // OR
            int _dummy_i2 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i1; } else goto label1;

            // CALLORVAR MultiplyFloat
            _Pantheon_Item _r9;

            _r9 = _MemoCall("MultiplyFloat", _index, MultiplyFloat, null);

            if (_r9 != null) _index = _r9.NextIndex;

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // CALLORVAR FloatValue
            _Pantheon_Item _r10;

            _r10 = _MemoCall("FloatValue", _index, FloatValue, null);

            if (_r10 != null) _index = _r10.NextIndex;

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void DoubleExpr(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item expr = null;

            // OR 0
            int _start_i0 = _index;

            // OR 1
            int _start_i1 = _index;

            // OR 2
            int _start_i2 = _index;

            // OR 5
            int _start_i5 = _index;

            // OR 6
            int _start_i6 = _index;

            // CALLORVAR IntegerExpr
            _Pantheon_Item _r7;

            _r7 = _MemoCall("IntegerExpr", _index, IntegerExpr, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i6; } else goto label6;

            // CALLORVAR LongExpr
            _Pantheon_Item _r8;

            _r8 = _MemoCall("LongExpr", _index, LongExpr, null);

            if (_r8 != null) _index = _r8.NextIndex;

        label6: // OR
            int _dummy_i6 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i5; } else goto label5;

            // CALLORVAR FloatExpr
            _Pantheon_Item _r9;

            _r9 = _MemoCall("FloatExpr", _index, FloatExpr, null);

            if (_r9 != null) _index = _r9.NextIndex;

        label5: // OR
            int _dummy_i5 = _index; // no-op for label

            // BIND expr
            expr = _results.Peek();

            // ACT
            var _r3 = _results.Peek();
            if (_r3 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r3.StartIndex, _r3.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Convert(expr, typeof(double)); }, _r3), true) );
            }

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i2; } else goto label2;

            // CALLORVAR AddDouble
            _Pantheon_Item _r10;

            _r10 = _MemoCall("AddDouble", _index, AddDouble, null);

            if (_r10 != null) _index = _r10.NextIndex;

        label2: // OR
            int _dummy_i2 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i1; } else goto label1;

            // CALLORVAR MultiplyDouble
            _Pantheon_Item _r11;

            _r11 = _MemoCall("MultiplyDouble", _index, MultiplyDouble, null);

            if (_r11 != null) _index = _r11.NextIndex;

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // CALLORVAR DoubleValue
            _Pantheon_Item _r12;

            _r12 = _MemoCall("DoubleValue", _index, DoubleValue, null);

            if (_r12 != null) _index = _r12.NextIndex;

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void Add(int _index, _Pantheon_Args _args)
        {

            int _arg_index = 0;
            int _arg_input_index = 0;

            _Pantheon_Item type = null;
            _Pantheon_Item left = null;
            _Pantheon_Item right = null;
            _Pantheon_Item subType = null;

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

            // OR 4
            int _start_i4 = _index;

            // AND 6
            int _start_i6 = _index;

            // AND 7
            int _start_i7 = _index;

            // AND 8
            int _start_i8 = _index;

            // AND 9
            int _start_i9 = _index;

            // CALL Add
            var _start_i11 = _index;
            _Pantheon_Item _r11;

            _r11 = _MemoCall("Add", _index, Add, new _Pantheon_Item[] { type });

            if (_r11 != null) _index = _r11.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label9; }

            // STAR 12
            int _start_i12 = _index;
            var _res12 = Enumerable.Empty<Expression>();
        label12:

            // CALLORVAR Whitespace
            _Pantheon_Item _r13;

            _r13 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r13 != null) _index = _r13.NextIndex;

            // STAR 12
            var _r12 = _results.Pop();
            if (_r12 != null)
            {
                _res12 = _res12.Concat(_r12.Results);
                goto label12;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i12, _index, _input_enumerable, _res12.Where(_NON_NULL), true));
            }

        label9: // AND
            var _r9_2 = _results.Pop();
            var _r9_1 = _results.Pop();

            if (_r9_1 != null && _r9_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i9, _index, _input_enumerable, _r9_1.Results.Concat(_r9_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i9;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label8; }

            // CALLORVAR Plus
            _Pantheon_Item _r14;

            _r14 = _MemoCall("Plus", _index, Plus, null);

            if (_r14 != null) _index = _r14.NextIndex;

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

            // STAR 15
            int _start_i15 = _index;
            var _res15 = Enumerable.Empty<Expression>();
        label15:

            // CALLORVAR Whitespace
            _Pantheon_Item _r16;

            _r16 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r16 != null) _index = _r16.NextIndex;

            // STAR 15
            var _r15 = _results.Pop();
            if (_r15 != null)
            {
                _res15 = _res15.Concat(_r15.Results);
                goto label15;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i15, _index, _input_enumerable, _res15.Where(_NON_NULL), true));
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

            // CALL Multiply
            var _start_i18 = _index;
            _Pantheon_Item _r18;

            _r18 = _MemoCall("Multiply", _index, Multiply, new _Pantheon_Item[] { type });

            if (_r18 != null) _index = _r18.NextIndex;

            // BIND right
            right = _results.Peek();

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

            // ACT
            var _r5 = _results.Peek();
            if (_r5 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r5.StartIndex, _r5.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Add(left, right); }, _r5), true) );
            }

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i4; } else goto label4;

            // AND 20
            int _start_i20 = _index;

            // AND 21
            int _start_i21 = _index;

            // AND 22
            int _start_i22 = _index;

            // AND 23
            int _start_i23 = _index;

            // CALL Multiply
            var _start_i25 = _index;
            _Pantheon_Item _r25;

            _r25 = _MemoCall("Multiply", _index, Multiply, new _Pantheon_Item[] { type });

            if (_r25 != null) _index = _r25.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label23; }

            // STAR 26
            int _start_i26 = _index;
            var _res26 = Enumerable.Empty<Expression>();
        label26:

            // CALLORVAR Whitespace
            _Pantheon_Item _r27;

            _r27 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r27 != null) _index = _r27.NextIndex;

            // STAR 26
            var _r26 = _results.Pop();
            if (_r26 != null)
            {
                _res26 = _res26.Concat(_r26.Results);
                goto label26;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i26, _index, _input_enumerable, _res26.Where(_NON_NULL), true));
            }

        label23: // AND
            var _r23_2 = _results.Pop();
            var _r23_1 = _results.Pop();

            if (_r23_1 != null && _r23_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i23, _index, _input_enumerable, _r23_1.Results.Concat(_r23_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i23;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label22; }

            // CALLORVAR Plus
            _Pantheon_Item _r28;

            _r28 = _MemoCall("Plus", _index, Plus, null);

            if (_r28 != null) _index = _r28.NextIndex;

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

            // STAR 29
            int _start_i29 = _index;
            var _res29 = Enumerable.Empty<Expression>();
        label29:

            // CALLORVAR Whitespace
            _Pantheon_Item _r30;

            _r30 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r30 != null) _index = _r30.NextIndex;

            // STAR 29
            var _r29 = _results.Pop();
            if (_r29 != null)
            {
                _res29 = _res29.Concat(_r29.Results);
                goto label29;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i29, _index, _input_enumerable, _res29.Where(_NON_NULL), true));
            }

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

            // CALL Multiply
            var _start_i32 = _index;
            _Pantheon_Item _r32;

            _r32 = _MemoCall("Multiply", _index, Multiply, new _Pantheon_Item[] { type });

            if (_r32 != null) _index = _r32.NextIndex;

            // BIND right
            right = _results.Peek();

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

            // ACT
            var _r19 = _results.Peek();
            if (_r19 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r19.StartIndex, _r19.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Add(left, right); }, _r19), true) );
            }

        label4: // OR
            int _dummy_i4 = _index; // no-op for label

        label1: // ARGS 1
            _arg_input_index = _arg_index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // ARGS 33
            _arg_index = 0;
            _arg_input_index = 0;

            // AND 34
            int _start_i34 = _arg_index;

            // ANY
            _ParseAnyArgs(ref _arg_index, ref _arg_input_index, _args);

            // BIND type
            type = _arg_results.Peek();

            // AND shortcut
            if (_arg_results.Peek() == null) { _arg_results.Push(null); goto label34; }

            // ANY
            _ParseAnyArgs(ref _arg_index, ref _arg_input_index, _args);

            // BIND subType
            subType = _arg_results.Peek();

        label34: // AND
            var _r34_2 = _arg_results.Pop();
            var _r34_1 = _arg_results.Pop();

            if (_r34_1 != null && _r34_2 != null)
            {
                _arg_results.Push(new _Pantheon_Item(_start_i34, _arg_index, _r34_1.Inputs.Concat(_r34_2.Inputs), _r34_1.Results.Concat(_r34_2.Results).Where(_NON_NULL), false));
            }
            else
            {
                _arg_results.Push(null);
                _arg_index = _start_i34;
            }

            if (_arg_results.Pop() == null)
            {
                _results.Push(null);
                goto label33;
            }

            // OR 39
            int _start_i39 = _index;

            // AND 41
            int _start_i41 = _index;

            // AND 42
            int _start_i42 = _index;

            // AND 43
            int _start_i43 = _index;

            // AND 44
            int _start_i44 = _index;

            // CALL Add
            var _start_i46 = _index;
            _Pantheon_Item _r46;

            _r46 = _MemoCall("Add", _index, Add, new _Pantheon_Item[] { type });

            if (_r46 != null) _index = _r46.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label44; }

            // STAR 47
            int _start_i47 = _index;
            var _res47 = Enumerable.Empty<Expression>();
        label47:

            // CALLORVAR Whitespace
            _Pantheon_Item _r48;

            _r48 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r48 != null) _index = _r48.NextIndex;

            // STAR 47
            var _r47 = _results.Pop();
            if (_r47 != null)
            {
                _res47 = _res47.Concat(_r47.Results);
                goto label47;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i47, _index, _input_enumerable, _res47.Where(_NON_NULL), true));
            }

        label44: // AND
            var _r44_2 = _results.Pop();
            var _r44_1 = _results.Pop();

            if (_r44_1 != null && _r44_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i44, _index, _input_enumerable, _r44_1.Results.Concat(_r44_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i44;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label43; }

            // CALLORVAR Plus
            _Pantheon_Item _r49;

            _r49 = _MemoCall("Plus", _index, Plus, null);

            if (_r49 != null) _index = _r49.NextIndex;

        label43: // AND
            var _r43_2 = _results.Pop();
            var _r43_1 = _results.Pop();

            if (_r43_1 != null && _r43_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i43, _index, _input_enumerable, _r43_1.Results.Concat(_r43_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i43;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label42; }

            // STAR 50
            int _start_i50 = _index;
            var _res50 = Enumerable.Empty<Expression>();
        label50:

            // CALLORVAR Whitespace
            _Pantheon_Item _r51;

            _r51 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r51 != null) _index = _r51.NextIndex;

            // STAR 50
            var _r50 = _results.Pop();
            if (_r50 != null)
            {
                _res50 = _res50.Concat(_r50.Results);
                goto label50;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i50, _index, _input_enumerable, _res50.Where(_NON_NULL), true));
            }

        label42: // AND
            var _r42_2 = _results.Pop();
            var _r42_1 = _results.Pop();

            if (_r42_1 != null && _r42_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i42, _index, _input_enumerable, _r42_1.Results.Concat(_r42_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i42;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label41; }

            // CALL Multiply
            var _start_i53 = _index;
            _Pantheon_Item _r53;

            _r53 = _MemoCall("Multiply", _index, Multiply, new _Pantheon_Item[] { type });

            if (_r53 != null) _index = _r53.NextIndex;

            // BIND right
            right = _results.Peek();

        label41: // AND
            var _r41_2 = _results.Pop();
            var _r41_1 = _results.Pop();

            if (_r41_1 != null && _r41_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i41, _index, _input_enumerable, _r41_1.Results.Concat(_r41_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i41;
            }

            // ACT
            var _r40 = _results.Peek();
            if (_r40 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r40.StartIndex, _r40.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Add(left, right); }, _r40), true) );
            }

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i39; } else goto label39;

            // AND 55
            int _start_i55 = _index;

            // AND 56
            int _start_i56 = _index;

            // AND 57
            int _start_i57 = _index;

            // AND 58
            int _start_i58 = _index;

            // CALL Multiply
            var _start_i60 = _index;
            _Pantheon_Item _r60;

            _r60 = _MemoCall("Multiply", _index, Multiply, new _Pantheon_Item[] { type });

            if (_r60 != null) _index = _r60.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label58; }

            // STAR 61
            int _start_i61 = _index;
            var _res61 = Enumerable.Empty<Expression>();
        label61:

            // CALLORVAR Whitespace
            _Pantheon_Item _r62;

            _r62 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r62 != null) _index = _r62.NextIndex;

            // STAR 61
            var _r61 = _results.Pop();
            if (_r61 != null)
            {
                _res61 = _res61.Concat(_r61.Results);
                goto label61;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i61, _index, _input_enumerable, _res61.Where(_NON_NULL), true));
            }

        label58: // AND
            var _r58_2 = _results.Pop();
            var _r58_1 = _results.Pop();

            if (_r58_1 != null && _r58_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i58, _index, _input_enumerable, _r58_1.Results.Concat(_r58_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i58;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label57; }

            // CALLORVAR Plus
            _Pantheon_Item _r63;

            _r63 = _MemoCall("Plus", _index, Plus, null);

            if (_r63 != null) _index = _r63.NextIndex;

        label57: // AND
            var _r57_2 = _results.Pop();
            var _r57_1 = _results.Pop();

            if (_r57_1 != null && _r57_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i57, _index, _input_enumerable, _r57_1.Results.Concat(_r57_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i57;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label56; }

            // STAR 64
            int _start_i64 = _index;
            var _res64 = Enumerable.Empty<Expression>();
        label64:

            // CALLORVAR Whitespace
            _Pantheon_Item _r65;

            _r65 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r65 != null) _index = _r65.NextIndex;

            // STAR 64
            var _r64 = _results.Pop();
            if (_r64 != null)
            {
                _res64 = _res64.Concat(_r64.Results);
                goto label64;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i64, _index, _input_enumerable, _res64.Where(_NON_NULL), true));
            }

        label56: // AND
            var _r56_2 = _results.Pop();
            var _r56_1 = _results.Pop();

            if (_r56_1 != null && _r56_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i56, _index, _input_enumerable, _r56_1.Results.Concat(_r56_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i56;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label55; }

            // CALL Multiply
            var _start_i67 = _index;
            _Pantheon_Item _r67;

            _r67 = _MemoCall("Multiply", _index, Multiply, new _Pantheon_Item[] { type });

            if (_r67 != null) _index = _r67.NextIndex;

            // BIND right
            right = _results.Peek();

        label55: // AND
            var _r55_2 = _results.Pop();
            var _r55_1 = _results.Pop();

            if (_r55_1 != null && _r55_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i55, _index, _input_enumerable, _r55_1.Results.Concat(_r55_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i55;
            }

            // ACT
            var _r54 = _results.Peek();
            if (_r54 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r54.StartIndex, _r54.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Add(left, right); }, _r54), true) );
            }

        label39: // OR
            int _dummy_i39 = _index; // no-op for label

        label33: // ARGS 33
            _arg_input_index = _arg_index; // no-op for label

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void Convert(int _index, _Pantheon_Args _args)
        {

            int _arg_index = 0;
            int _arg_input_index = 0;

            _Pantheon_Item exprType = null;
            _Pantheon_Item from = null;
            _Pantheon_Item to = null;
            _Pantheon_Item expr = null;

            // ARGS 0
            _arg_index = 0;
            _arg_input_index = 0;

            // AND 1
            int _start_i1 = _arg_index;

            // AND 2
            int _start_i2 = _arg_index;

            // ANY
            _ParseAnyArgs(ref _arg_index, ref _arg_input_index, _args);

            // BIND exprType
            exprType = _arg_results.Peek();

            // AND shortcut
            if (_arg_results.Peek() == null) { _arg_results.Push(null); goto label2; }

            // ANY
            _ParseAnyArgs(ref _arg_index, ref _arg_input_index, _args);

            // BIND from
            from = _arg_results.Peek();

        label2: // AND
            var _r2_2 = _arg_results.Pop();
            var _r2_1 = _arg_results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _arg_results.Push(new _Pantheon_Item(_start_i2, _arg_index, _r2_1.Inputs.Concat(_r2_2.Inputs), _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), false));
            }
            else
            {
                _arg_results.Push(null);
                _arg_index = _start_i2;
            }

            // AND shortcut
            if (_arg_results.Peek() == null) { _arg_results.Push(null); goto label1; }

            // ANY
            _ParseAnyArgs(ref _arg_index, ref _arg_input_index, _args);

            // BIND to
            to = _arg_results.Peek();

        label1: // AND
            var _r1_2 = _arg_results.Pop();
            var _r1_1 = _arg_results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _arg_results.Push(new _Pantheon_Item(_start_i1, _arg_index, _r1_1.Inputs.Concat(_r1_2.Inputs), _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), false));
            }
            else
            {
                _arg_results.Push(null);
                _arg_index = _start_i1;
            }

            if (_arg_results.Pop() == null)
            {
                _results.Push(null);
                goto label0;
            }

            // CALL exprType
            var _start_i11 = _index;
            _Pantheon_Item _r11;

            _r11 = _MemoCall(exprType.ProductionName, _index, exprType.Production, new _Pantheon_Item[] { from });

            if (_r11 != null) _index = _r11.NextIndex;

            // BIND expr
            expr = _results.Peek();

            // ACT
            var _r9 = _results.Peek();
            if (_r9 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r9.StartIndex, _r9.NextIndex, _input_enumerable, _Thunk(_IM_Result => { Console.WriteLine((Expression)to); return Expression.Convert(expr, ((Expression)to).Type); }, _r9), true) );
            }

        label0: // ARGS 0
            _arg_input_index = _arg_index; // no-op for label

        }


        public void AddInteger(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item left = null;
            _Pantheon_Item right = null;

            // OR 0
            int _start_i0 = _index;

            // AND 2
            int _start_i2 = _index;

            // AND 3
            int _start_i3 = _index;

            // AND 4
            int _start_i4 = _index;

            // AND 5
            int _start_i5 = _index;

            // CALLORVAR AddInteger
            _Pantheon_Item _r7;

            _r7 = _MemoCall("AddInteger", _index, AddInteger, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label5; }

            // STAR 8
            int _start_i8 = _index;
            var _res8 = Enumerable.Empty<Expression>();
        label8:

            // CALLORVAR Whitespace
            _Pantheon_Item _r9;

            _r9 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r9 != null) _index = _r9.NextIndex;

            // STAR 8
            var _r8 = _results.Pop();
            if (_r8 != null)
            {
                _res8 = _res8.Concat(_r8.Results);
                goto label8;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i8, _index, _input_enumerable, _res8.Where(_NON_NULL), true));
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

            // CALLORVAR Plus
            _Pantheon_Item _r10;

            _r10 = _MemoCall("Plus", _index, Plus, null);

            if (_r10 != null) _index = _r10.NextIndex;

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

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label3; }

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

        label3: // AND
            var _r3_2 = _results.Pop();
            var _r3_1 = _results.Pop();

            if (_r3_1 != null && _r3_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i3, _index, _input_enumerable, _r3_1.Results.Concat(_r3_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i3;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label2; }

            // CALLORVAR MultiplyInteger
            _Pantheon_Item _r14;

            _r14 = _MemoCall("MultiplyInteger", _index, MultiplyInteger, null);

            if (_r14 != null) _index = _r14.NextIndex;

            // BIND right
            right = _results.Peek();

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

            // ACT
            var _r1 = _results.Peek();
            if (_r1 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r1.StartIndex, _r1.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Add(left, right); }, _r1), true) );
            }

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // AND 16
            int _start_i16 = _index;

            // AND 17
            int _start_i17 = _index;

            // AND 18
            int _start_i18 = _index;

            // AND 19
            int _start_i19 = _index;

            // CALLORVAR MultiplyInteger
            _Pantheon_Item _r21;

            _r21 = _MemoCall("MultiplyInteger", _index, MultiplyInteger, null);

            if (_r21 != null) _index = _r21.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label19; }

            // STAR 22
            int _start_i22 = _index;
            var _res22 = Enumerable.Empty<Expression>();
        label22:

            // CALLORVAR Whitespace
            _Pantheon_Item _r23;

            _r23 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r23 != null) _index = _r23.NextIndex;

            // STAR 22
            var _r22 = _results.Pop();
            if (_r22 != null)
            {
                _res22 = _res22.Concat(_r22.Results);
                goto label22;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i22, _index, _input_enumerable, _res22.Where(_NON_NULL), true));
            }

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

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label18; }

            // CALLORVAR Plus
            _Pantheon_Item _r24;

            _r24 = _MemoCall("Plus", _index, Plus, null);

            if (_r24 != null) _index = _r24.NextIndex;

        label18: // AND
            var _r18_2 = _results.Pop();
            var _r18_1 = _results.Pop();

            if (_r18_1 != null && _r18_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i18, _index, _input_enumerable, _r18_1.Results.Concat(_r18_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i18;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label17; }

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

        label17: // AND
            var _r17_2 = _results.Pop();
            var _r17_1 = _results.Pop();

            if (_r17_1 != null && _r17_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i17, _index, _input_enumerable, _r17_1.Results.Concat(_r17_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i17;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label16; }

            // CALLORVAR MultiplyInteger
            _Pantheon_Item _r28;

            _r28 = _MemoCall("MultiplyInteger", _index, MultiplyInteger, null);

            if (_r28 != null) _index = _r28.NextIndex;

            // BIND right
            right = _results.Peek();

        label16: // AND
            var _r16_2 = _results.Pop();
            var _r16_1 = _results.Pop();

            if (_r16_1 != null && _r16_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i16, _index, _input_enumerable, _r16_1.Results.Concat(_r16_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i16;
            }

            // ACT
            var _r15 = _results.Peek();
            if (_r15 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r15.StartIndex, _r15.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Add(left, right); }, _r15), true) );
            }

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void AddLong(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item left = null;
            _Pantheon_Item right = null;

            // OR 0
            int _start_i0 = _index;

            // OR 1
            int _start_i1 = _index;

            // AND 3
            int _start_i3 = _index;

            // AND 4
            int _start_i4 = _index;

            // AND 5
            int _start_i5 = _index;

            // AND 6
            int _start_i6 = _index;

            // CALLORVAR AddLong
            _Pantheon_Item _r8;

            _r8 = _MemoCall("AddLong", _index, AddLong, null);

            if (_r8 != null) _index = _r8.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label6; }

            // STAR 9
            int _start_i9 = _index;
            var _res9 = Enumerable.Empty<Expression>();
        label9:

            // CALLORVAR Whitespace
            _Pantheon_Item _r10;

            _r10 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r10 != null) _index = _r10.NextIndex;

            // STAR 9
            var _r9 = _results.Pop();
            if (_r9 != null)
            {
                _res9 = _res9.Concat(_r9.Results);
                goto label9;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i9, _index, _input_enumerable, _res9.Where(_NON_NULL), true));
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

            // CALLORVAR Plus
            _Pantheon_Item _r11;

            _r11 = _MemoCall("Plus", _index, Plus, null);

            if (_r11 != null) _index = _r11.NextIndex;

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

            // STAR 12
            int _start_i12 = _index;
            var _res12 = Enumerable.Empty<Expression>();
        label12:

            // CALLORVAR Whitespace
            _Pantheon_Item _r13;

            _r13 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r13 != null) _index = _r13.NextIndex;

            // STAR 12
            var _r12 = _results.Pop();
            if (_r12 != null)
            {
                _res12 = _res12.Concat(_r12.Results);
                goto label12;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i12, _index, _input_enumerable, _res12.Where(_NON_NULL), true));
            }

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

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label3; }

            // CALLORVAR MultiplyLong
            _Pantheon_Item _r15;

            _r15 = _MemoCall("MultiplyLong", _index, MultiplyLong, null);

            if (_r15 != null) _index = _r15.NextIndex;

            // BIND right
            right = _results.Peek();

        label3: // AND
            var _r3_2 = _results.Pop();
            var _r3_1 = _results.Pop();

            if (_r3_1 != null && _r3_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i3, _index, _input_enumerable, _r3_1.Results.Concat(_r3_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i3;
            }

            // ACT
            var _r2 = _results.Peek();
            if (_r2 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r2.StartIndex, _r2.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Add(left, right); }, _r2), true) );
            }

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i1; } else goto label1;

            // AND 17
            int _start_i17 = _index;

            // AND 18
            int _start_i18 = _index;

            // AND 19
            int _start_i19 = _index;

            // AND 20
            int _start_i20 = _index;

            // CALLORVAR AddInteger
            _Pantheon_Item _r22;

            _r22 = _MemoCall("AddInteger", _index, AddInteger, null);

            if (_r22 != null) _index = _r22.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label20; }

            // STAR 23
            int _start_i23 = _index;
            var _res23 = Enumerable.Empty<Expression>();
        label23:

            // CALLORVAR Whitespace
            _Pantheon_Item _r24;

            _r24 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r24 != null) _index = _r24.NextIndex;

            // STAR 23
            var _r23 = _results.Pop();
            if (_r23 != null)
            {
                _res23 = _res23.Concat(_r23.Results);
                goto label23;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i23, _index, _input_enumerable, _res23.Where(_NON_NULL), true));
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

            // CALLORVAR Plus
            _Pantheon_Item _r25;

            _r25 = _MemoCall("Plus", _index, Plus, null);

            if (_r25 != null) _index = _r25.NextIndex;

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

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label18; }

            // STAR 26
            int _start_i26 = _index;
            var _res26 = Enumerable.Empty<Expression>();
        label26:

            // CALLORVAR Whitespace
            _Pantheon_Item _r27;

            _r27 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r27 != null) _index = _r27.NextIndex;

            // STAR 26
            var _r26 = _results.Pop();
            if (_r26 != null)
            {
                _res26 = _res26.Concat(_r26.Results);
                goto label26;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i26, _index, _input_enumerable, _res26.Where(_NON_NULL), true));
            }

        label18: // AND
            var _r18_2 = _results.Pop();
            var _r18_1 = _results.Pop();

            if (_r18_1 != null && _r18_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i18, _index, _input_enumerable, _r18_1.Results.Concat(_r18_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i18;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label17; }

            // CALLORVAR MultiplyLong
            _Pantheon_Item _r29;

            _r29 = _MemoCall("MultiplyLong", _index, MultiplyLong, null);

            if (_r29 != null) _index = _r29.NextIndex;

            // BIND right
            right = _results.Peek();

        label17: // AND
            var _r17_2 = _results.Pop();
            var _r17_1 = _results.Pop();

            if (_r17_1 != null && _r17_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i17, _index, _input_enumerable, _r17_1.Results.Concat(_r17_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i17;
            }

            // ACT
            var _r16 = _results.Peek();
            if (_r16 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r16.StartIndex, _r16.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Add(Expression.Convert(left, typeof(long)), right); }, _r16), true) );
            }

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // AND 31
            int _start_i31 = _index;

            // AND 32
            int _start_i32 = _index;

            // AND 33
            int _start_i33 = _index;

            // AND 34
            int _start_i34 = _index;

            // CALLORVAR MultiplyLong
            _Pantheon_Item _r36;

            _r36 = _MemoCall("MultiplyLong", _index, MultiplyLong, null);

            if (_r36 != null) _index = _r36.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label34; }

            // STAR 37
            int _start_i37 = _index;
            var _res37 = Enumerable.Empty<Expression>();
        label37:

            // CALLORVAR Whitespace
            _Pantheon_Item _r38;

            _r38 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r38 != null) _index = _r38.NextIndex;

            // STAR 37
            var _r37 = _results.Pop();
            if (_r37 != null)
            {
                _res37 = _res37.Concat(_r37.Results);
                goto label37;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i37, _index, _input_enumerable, _res37.Where(_NON_NULL), true));
            }

        label34: // AND
            var _r34_2 = _results.Pop();
            var _r34_1 = _results.Pop();

            if (_r34_1 != null && _r34_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i34, _index, _input_enumerable, _r34_1.Results.Concat(_r34_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i34;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label33; }

            // CALLORVAR Plus
            _Pantheon_Item _r39;

            _r39 = _MemoCall("Plus", _index, Plus, null);

            if (_r39 != null) _index = _r39.NextIndex;

        label33: // AND
            var _r33_2 = _results.Pop();
            var _r33_1 = _results.Pop();

            if (_r33_1 != null && _r33_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i33, _index, _input_enumerable, _r33_1.Results.Concat(_r33_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i33;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label32; }

            // STAR 40
            int _start_i40 = _index;
            var _res40 = Enumerable.Empty<Expression>();
        label40:

            // CALLORVAR Whitespace
            _Pantheon_Item _r41;

            _r41 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r41 != null) _index = _r41.NextIndex;

            // STAR 40
            var _r40 = _results.Pop();
            if (_r40 != null)
            {
                _res40 = _res40.Concat(_r40.Results);
                goto label40;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i40, _index, _input_enumerable, _res40.Where(_NON_NULL), true));
            }

        label32: // AND
            var _r32_2 = _results.Pop();
            var _r32_1 = _results.Pop();

            if (_r32_1 != null && _r32_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i32, _index, _input_enumerable, _r32_1.Results.Concat(_r32_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i32;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label31; }

            // CALLORVAR MultiplyLong
            _Pantheon_Item _r43;

            _r43 = _MemoCall("MultiplyLong", _index, MultiplyLong, null);

            if (_r43 != null) _index = _r43.NextIndex;

            // BIND right
            right = _results.Peek();

        label31: // AND
            var _r31_2 = _results.Pop();
            var _r31_1 = _results.Pop();

            if (_r31_1 != null && _r31_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i31, _index, _input_enumerable, _r31_1.Results.Concat(_r31_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i31;
            }

            // ACT
            var _r30 = _results.Peek();
            if (_r30 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r30.StartIndex, _r30.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Add(left, right); }, _r30), true) );
            }

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void AddFloat(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item left = null;
            _Pantheon_Item right = null;

            // OR 0
            int _start_i0 = _index;

            // OR 1
            int _start_i1 = _index;

            // AND 3
            int _start_i3 = _index;

            // AND 4
            int _start_i4 = _index;

            // AND 5
            int _start_i5 = _index;

            // AND 6
            int _start_i6 = _index;

            // CALLORVAR AddFloat
            _Pantheon_Item _r8;

            _r8 = _MemoCall("AddFloat", _index, AddFloat, null);

            if (_r8 != null) _index = _r8.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label6; }

            // STAR 9
            int _start_i9 = _index;
            var _res9 = Enumerable.Empty<Expression>();
        label9:

            // CALLORVAR Whitespace
            _Pantheon_Item _r10;

            _r10 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r10 != null) _index = _r10.NextIndex;

            // STAR 9
            var _r9 = _results.Pop();
            if (_r9 != null)
            {
                _res9 = _res9.Concat(_r9.Results);
                goto label9;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i9, _index, _input_enumerable, _res9.Where(_NON_NULL), true));
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

            // CALLORVAR Plus
            _Pantheon_Item _r11;

            _r11 = _MemoCall("Plus", _index, Plus, null);

            if (_r11 != null) _index = _r11.NextIndex;

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

            // STAR 12
            int _start_i12 = _index;
            var _res12 = Enumerable.Empty<Expression>();
        label12:

            // CALLORVAR Whitespace
            _Pantheon_Item _r13;

            _r13 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r13 != null) _index = _r13.NextIndex;

            // STAR 12
            var _r12 = _results.Pop();
            if (_r12 != null)
            {
                _res12 = _res12.Concat(_r12.Results);
                goto label12;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i12, _index, _input_enumerable, _res12.Where(_NON_NULL), true));
            }

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

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label3; }

            // CALLORVAR MultiplyFloat
            _Pantheon_Item _r15;

            _r15 = _MemoCall("MultiplyFloat", _index, MultiplyFloat, null);

            if (_r15 != null) _index = _r15.NextIndex;

            // BIND right
            right = _results.Peek();

        label3: // AND
            var _r3_2 = _results.Pop();
            var _r3_1 = _results.Pop();

            if (_r3_1 != null && _r3_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i3, _index, _input_enumerable, _r3_1.Results.Concat(_r3_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i3;
            }

            // ACT
            var _r2 = _results.Peek();
            if (_r2 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r2.StartIndex, _r2.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Add(left, right); }, _r2), true) );
            }

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i1; } else goto label1;

            // AND 17
            int _start_i17 = _index;

            // AND 18
            int _start_i18 = _index;

            // AND 19
            int _start_i19 = _index;

            // AND 20
            int _start_i20 = _index;

            // CALLORVAR AddInteger
            _Pantheon_Item _r22;

            _r22 = _MemoCall("AddInteger", _index, AddInteger, null);

            if (_r22 != null) _index = _r22.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label20; }

            // STAR 23
            int _start_i23 = _index;
            var _res23 = Enumerable.Empty<Expression>();
        label23:

            // CALLORVAR Whitespace
            _Pantheon_Item _r24;

            _r24 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r24 != null) _index = _r24.NextIndex;

            // STAR 23
            var _r23 = _results.Pop();
            if (_r23 != null)
            {
                _res23 = _res23.Concat(_r23.Results);
                goto label23;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i23, _index, _input_enumerable, _res23.Where(_NON_NULL), true));
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

            // CALLORVAR Plus
            _Pantheon_Item _r25;

            _r25 = _MemoCall("Plus", _index, Plus, null);

            if (_r25 != null) _index = _r25.NextIndex;

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

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label18; }

            // STAR 26
            int _start_i26 = _index;
            var _res26 = Enumerable.Empty<Expression>();
        label26:

            // CALLORVAR Whitespace
            _Pantheon_Item _r27;

            _r27 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r27 != null) _index = _r27.NextIndex;

            // STAR 26
            var _r26 = _results.Pop();
            if (_r26 != null)
            {
                _res26 = _res26.Concat(_r26.Results);
                goto label26;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i26, _index, _input_enumerable, _res26.Where(_NON_NULL), true));
            }

        label18: // AND
            var _r18_2 = _results.Pop();
            var _r18_1 = _results.Pop();

            if (_r18_1 != null && _r18_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i18, _index, _input_enumerable, _r18_1.Results.Concat(_r18_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i18;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label17; }

            // CALLORVAR MultiplyFloat
            _Pantheon_Item _r29;

            _r29 = _MemoCall("MultiplyFloat", _index, MultiplyFloat, null);

            if (_r29 != null) _index = _r29.NextIndex;

            // BIND right
            right = _results.Peek();

        label17: // AND
            var _r17_2 = _results.Pop();
            var _r17_1 = _results.Pop();

            if (_r17_1 != null && _r17_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i17, _index, _input_enumerable, _r17_1.Results.Concat(_r17_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i17;
            }

            // ACT
            var _r16 = _results.Peek();
            if (_r16 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r16.StartIndex, _r16.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Add(Expression.Convert(left, typeof(float)), right); }, _r16), true) );
            }

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // AND 31
            int _start_i31 = _index;

            // AND 32
            int _start_i32 = _index;

            // AND 33
            int _start_i33 = _index;

            // AND 34
            int _start_i34 = _index;

            // CALLORVAR MultiplyFloat
            _Pantheon_Item _r36;

            _r36 = _MemoCall("MultiplyFloat", _index, MultiplyFloat, null);

            if (_r36 != null) _index = _r36.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label34; }

            // STAR 37
            int _start_i37 = _index;
            var _res37 = Enumerable.Empty<Expression>();
        label37:

            // CALLORVAR Whitespace
            _Pantheon_Item _r38;

            _r38 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r38 != null) _index = _r38.NextIndex;

            // STAR 37
            var _r37 = _results.Pop();
            if (_r37 != null)
            {
                _res37 = _res37.Concat(_r37.Results);
                goto label37;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i37, _index, _input_enumerable, _res37.Where(_NON_NULL), true));
            }

        label34: // AND
            var _r34_2 = _results.Pop();
            var _r34_1 = _results.Pop();

            if (_r34_1 != null && _r34_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i34, _index, _input_enumerable, _r34_1.Results.Concat(_r34_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i34;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label33; }

            // CALLORVAR Plus
            _Pantheon_Item _r39;

            _r39 = _MemoCall("Plus", _index, Plus, null);

            if (_r39 != null) _index = _r39.NextIndex;

        label33: // AND
            var _r33_2 = _results.Pop();
            var _r33_1 = _results.Pop();

            if (_r33_1 != null && _r33_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i33, _index, _input_enumerable, _r33_1.Results.Concat(_r33_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i33;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label32; }

            // STAR 40
            int _start_i40 = _index;
            var _res40 = Enumerable.Empty<Expression>();
        label40:

            // CALLORVAR Whitespace
            _Pantheon_Item _r41;

            _r41 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r41 != null) _index = _r41.NextIndex;

            // STAR 40
            var _r40 = _results.Pop();
            if (_r40 != null)
            {
                _res40 = _res40.Concat(_r40.Results);
                goto label40;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i40, _index, _input_enumerable, _res40.Where(_NON_NULL), true));
            }

        label32: // AND
            var _r32_2 = _results.Pop();
            var _r32_1 = _results.Pop();

            if (_r32_1 != null && _r32_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i32, _index, _input_enumerable, _r32_1.Results.Concat(_r32_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i32;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label31; }

            // CALLORVAR MultiplyFloat
            _Pantheon_Item _r43;

            _r43 = _MemoCall("MultiplyFloat", _index, MultiplyFloat, null);

            if (_r43 != null) _index = _r43.NextIndex;

            // BIND right
            right = _results.Peek();

        label31: // AND
            var _r31_2 = _results.Pop();
            var _r31_1 = _results.Pop();

            if (_r31_1 != null && _r31_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i31, _index, _input_enumerable, _r31_1.Results.Concat(_r31_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i31;
            }

            // ACT
            var _r30 = _results.Peek();
            if (_r30 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r30.StartIndex, _r30.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Add(left, right); }, _r30), true) );
            }

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void AddDouble(int _index, _Pantheon_Args _args)
        {

            _Pantheon_Item left = null;
            _Pantheon_Item right = null;

            // OR 0
            int _start_i0 = _index;

            // OR 1
            int _start_i1 = _index;

            // AND 3
            int _start_i3 = _index;

            // AND 4
            int _start_i4 = _index;

            // AND 5
            int _start_i5 = _index;

            // AND 6
            int _start_i6 = _index;

            // CALLORVAR AddDouble
            _Pantheon_Item _r8;

            _r8 = _MemoCall("AddDouble", _index, AddDouble, null);

            if (_r8 != null) _index = _r8.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label6; }

            // STAR 9
            int _start_i9 = _index;
            var _res9 = Enumerable.Empty<Expression>();
        label9:

            // CALLORVAR Whitespace
            _Pantheon_Item _r10;

            _r10 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r10 != null) _index = _r10.NextIndex;

            // STAR 9
            var _r9 = _results.Pop();
            if (_r9 != null)
            {
                _res9 = _res9.Concat(_r9.Results);
                goto label9;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i9, _index, _input_enumerable, _res9.Where(_NON_NULL), true));
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

            // CALLORVAR Plus
            _Pantheon_Item _r11;

            _r11 = _MemoCall("Plus", _index, Plus, null);

            if (_r11 != null) _index = _r11.NextIndex;

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

            // STAR 12
            int _start_i12 = _index;
            var _res12 = Enumerable.Empty<Expression>();
        label12:

            // CALLORVAR Whitespace
            _Pantheon_Item _r13;

            _r13 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r13 != null) _index = _r13.NextIndex;

            // STAR 12
            var _r12 = _results.Pop();
            if (_r12 != null)
            {
                _res12 = _res12.Concat(_r12.Results);
                goto label12;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i12, _index, _input_enumerable, _res12.Where(_NON_NULL), true));
            }

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

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label3; }

            // CALLORVAR MultiplyDouble
            _Pantheon_Item _r15;

            _r15 = _MemoCall("MultiplyDouble", _index, MultiplyDouble, null);

            if (_r15 != null) _index = _r15.NextIndex;

            // BIND right
            right = _results.Peek();

        label3: // AND
            var _r3_2 = _results.Pop();
            var _r3_1 = _results.Pop();

            if (_r3_1 != null && _r3_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i3, _index, _input_enumerable, _r3_1.Results.Concat(_r3_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i3;
            }

            // ACT
            var _r2 = _results.Peek();
            if (_r2 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r2.StartIndex, _r2.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Add(left, right); }, _r2), true) );
            }

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i1; } else goto label1;

            // AND 17
            int _start_i17 = _index;

            // AND 18
            int _start_i18 = _index;

            // AND 19
            int _start_i19 = _index;

            // AND 20
            int _start_i20 = _index;

            // CALLORVAR AddFloat
            _Pantheon_Item _r22;

            _r22 = _MemoCall("AddFloat", _index, AddFloat, null);

            if (_r22 != null) _index = _r22.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label20; }

            // STAR 23
            int _start_i23 = _index;
            var _res23 = Enumerable.Empty<Expression>();
        label23:

            // CALLORVAR Whitespace
            _Pantheon_Item _r24;

            _r24 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r24 != null) _index = _r24.NextIndex;

            // STAR 23
            var _r23 = _results.Pop();
            if (_r23 != null)
            {
                _res23 = _res23.Concat(_r23.Results);
                goto label23;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i23, _index, _input_enumerable, _res23.Where(_NON_NULL), true));
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

            // CALLORVAR Plus
            _Pantheon_Item _r25;

            _r25 = _MemoCall("Plus", _index, Plus, null);

            if (_r25 != null) _index = _r25.NextIndex;

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

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label18; }

            // STAR 26
            int _start_i26 = _index;
            var _res26 = Enumerable.Empty<Expression>();
        label26:

            // CALLORVAR Whitespace
            _Pantheon_Item _r27;

            _r27 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r27 != null) _index = _r27.NextIndex;

            // STAR 26
            var _r26 = _results.Pop();
            if (_r26 != null)
            {
                _res26 = _res26.Concat(_r26.Results);
                goto label26;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i26, _index, _input_enumerable, _res26.Where(_NON_NULL), true));
            }

        label18: // AND
            var _r18_2 = _results.Pop();
            var _r18_1 = _results.Pop();

            if (_r18_1 != null && _r18_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i18, _index, _input_enumerable, _r18_1.Results.Concat(_r18_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i18;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label17; }

            // CALLORVAR MultiplyDouble
            _Pantheon_Item _r29;

            _r29 = _MemoCall("MultiplyDouble", _index, MultiplyDouble, null);

            if (_r29 != null) _index = _r29.NextIndex;

            // BIND right
            right = _results.Peek();

        label17: // AND
            var _r17_2 = _results.Pop();
            var _r17_1 = _results.Pop();

            if (_r17_1 != null && _r17_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i17, _index, _input_enumerable, _r17_1.Results.Concat(_r17_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i17;
            }

            // ACT
            var _r16 = _results.Peek();
            if (_r16 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r16.StartIndex, _r16.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Add(Expression.Convert(left, typeof(double)), right); }, _r16), true) );
            }

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // AND 31
            int _start_i31 = _index;

            // AND 32
            int _start_i32 = _index;

            // AND 33
            int _start_i33 = _index;

            // AND 34
            int _start_i34 = _index;

            // CALLORVAR MultiplyDouble
            _Pantheon_Item _r36;

            _r36 = _MemoCall("MultiplyDouble", _index, MultiplyDouble, null);

            if (_r36 != null) _index = _r36.NextIndex;

            // BIND left
            left = _results.Peek();

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label34; }

            // STAR 37
            int _start_i37 = _index;
            var _res37 = Enumerable.Empty<Expression>();
        label37:

            // CALLORVAR Whitespace
            _Pantheon_Item _r38;

            _r38 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r38 != null) _index = _r38.NextIndex;

            // STAR 37
            var _r37 = _results.Pop();
            if (_r37 != null)
            {
                _res37 = _res37.Concat(_r37.Results);
                goto label37;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i37, _index, _input_enumerable, _res37.Where(_NON_NULL), true));
            }

        label34: // AND
            var _r34_2 = _results.Pop();
            var _r34_1 = _results.Pop();

            if (_r34_1 != null && _r34_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i34, _index, _input_enumerable, _r34_1.Results.Concat(_r34_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i34;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label33; }

            // CALLORVAR Plus
            _Pantheon_Item _r39;

            _r39 = _MemoCall("Plus", _index, Plus, null);

            if (_r39 != null) _index = _r39.NextIndex;

        label33: // AND
            var _r33_2 = _results.Pop();
            var _r33_1 = _results.Pop();

            if (_r33_1 != null && _r33_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i33, _index, _input_enumerable, _r33_1.Results.Concat(_r33_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i33;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label32; }

            // STAR 40
            int _start_i40 = _index;
            var _res40 = Enumerable.Empty<Expression>();
        label40:

            // CALLORVAR Whitespace
            _Pantheon_Item _r41;

            _r41 = _MemoCall("Whitespace", _index, Whitespace, null);

            if (_r41 != null) _index = _r41.NextIndex;

            // STAR 40
            var _r40 = _results.Pop();
            if (_r40 != null)
            {
                _res40 = _res40.Concat(_r40.Results);
                goto label40;
            }
            else
            {
                _results.Push(new _Pantheon_Item(_start_i40, _index, _input_enumerable, _res40.Where(_NON_NULL), true));
            }

        label32: // AND
            var _r32_2 = _results.Pop();
            var _r32_1 = _results.Pop();

            if (_r32_1 != null && _r32_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i32, _index, _input_enumerable, _r32_1.Results.Concat(_r32_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i32;
            }

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label31; }

            // CALLORVAR MultiplyDouble
            _Pantheon_Item _r43;

            _r43 = _MemoCall("MultiplyDouble", _index, MultiplyDouble, null);

            if (_r43 != null) _index = _r43.NextIndex;

            // BIND right
            right = _results.Peek();

        label31: // AND
            var _r31_2 = _results.Pop();
            var _r31_1 = _results.Pop();

            if (_r31_1 != null && _r31_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i31, _index, _input_enumerable, _r31_1.Results.Concat(_r31_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i31;
            }

            // ACT
            var _r30 = _results.Peek();
            if (_r30 != null)
            {
                _results.Pop();
                _results.Push( new _Pantheon_Item(_r30.StartIndex, _r30.NextIndex, _input_enumerable, _Thunk(_IM_Result => { return Expression.Add(left, right); }, _r30), true) );
            }

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void Expr(int _index, _Pantheon_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

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

            // OR 6
            int _start_i6 = _index;

            // OR 7
            int _start_i7 = _index;

            // AND 8
            int _start_i8 = _index;

            // CALL Add
            var _start_i9 = _index;
            _Pantheon_Item _r9;

            _r9 = _MemoCall("Add", _index, Add, new _Pantheon_Item[] { new _Pantheon_Item(IntegerValue) });

            if (_r9 != null) _index = _r9.NextIndex;

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label8; }

            // NOT 10
            int _start_i10 = _index;

            // ANY
            _ParseAny(ref _index);

            // NOT 10
            var _r10 = _results.Pop();
            _results.Push( _r10 == null ? new _Pantheon_Item(_start_i10, _input_enumerable) : null);
            _index = _start_i10;
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

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i7; } else goto label7;

            // AND 12
            int _start_i12 = _index;

            // CALL Add
            var _start_i13 = _index;
            _Pantheon_Item _r13;

            _r13 = _MemoCall("Add", _index, Add, new _Pantheon_Item[] { new _Pantheon_Item(LongValue), new _Pantheon_Item(IntegerValue) });

            if (_r13 != null) _index = _r13.NextIndex;

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label12; }

            // NOT 14
            int _start_i14 = _index;

            // ANY
            _ParseAny(ref _index);

            // NOT 14
            var _r14 = _results.Pop();
            _results.Push( _r14 == null ? new _Pantheon_Item(_start_i14, _input_enumerable) : null);
            _index = _start_i14;
        label12: // AND
            var _r12_2 = _results.Pop();
            var _r12_1 = _results.Pop();

            if (_r12_1 != null && _r12_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i12, _index, _input_enumerable, _r12_1.Results.Concat(_r12_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i12;
            }

        label7: // OR
            int _dummy_i7 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i6; } else goto label6;

            // AND 16
            int _start_i16 = _index;

            // CALL Add
            var _start_i17 = _index;
            _Pantheon_Item _r17;

            _r17 = _MemoCall("Add", _index, Add, new _Pantheon_Item[] { new _Pantheon_Item(FloatValue), new _Pantheon_Item(IntegerValue) });

            if (_r17 != null) _index = _r17.NextIndex;

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label16; }

            // NOT 18
            int _start_i18 = _index;

            // ANY
            _ParseAny(ref _index);

            // NOT 18
            var _r18 = _results.Pop();
            _results.Push( _r18 == null ? new _Pantheon_Item(_start_i18, _input_enumerable) : null);
            _index = _start_i18;
        label16: // AND
            var _r16_2 = _results.Pop();
            var _r16_1 = _results.Pop();

            if (_r16_1 != null && _r16_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i16, _index, _input_enumerable, _r16_1.Results.Concat(_r16_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i16;
            }

        label6: // OR
            int _dummy_i6 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i5; } else goto label5;

            // AND 20
            int _start_i20 = _index;

            // CALL Add
            var _start_i21 = _index;
            _Pantheon_Item _r21;

            _r21 = _MemoCall("Add", _index, Add, new _Pantheon_Item[] { new _Pantheon_Item(DoubleValue), new _Pantheon_Item(FloatValue) });

            if (_r21 != null) _index = _r21.NextIndex;

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label20; }

            // NOT 22
            int _start_i22 = _index;

            // ANY
            _ParseAny(ref _index);

            // NOT 22
            var _r22 = _results.Pop();
            _results.Push( _r22 == null ? new _Pantheon_Item(_start_i22, _input_enumerable) : null);
            _index = _start_i22;
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

        label5: // OR
            int _dummy_i5 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i4; } else goto label4;

            // AND 24
            int _start_i24 = _index;

            // CALL Multiply
            var _start_i25 = _index;
            _Pantheon_Item _r25;

            _r25 = _MemoCall("Multiply", _index, Multiply, new _Pantheon_Item[] { new _Pantheon_Item(IntegerValue) });

            if (_r25 != null) _index = _r25.NextIndex;

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label24; }

            // NOT 26
            int _start_i26 = _index;

            // ANY
            _ParseAny(ref _index);

            // NOT 26
            var _r26 = _results.Pop();
            _results.Push( _r26 == null ? new _Pantheon_Item(_start_i26, _input_enumerable) : null);
            _index = _start_i26;
        label24: // AND
            var _r24_2 = _results.Pop();
            var _r24_1 = _results.Pop();

            if (_r24_1 != null && _r24_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i24, _index, _input_enumerable, _r24_1.Results.Concat(_r24_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i24;
            }

        label4: // OR
            int _dummy_i4 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i3; } else goto label3;

            // AND 28
            int _start_i28 = _index;

            // CALL Multiply
            var _start_i29 = _index;
            _Pantheon_Item _r29;

            _r29 = _MemoCall("Multiply", _index, Multiply, new _Pantheon_Item[] { new _Pantheon_Item(LongValue) });

            if (_r29 != null) _index = _r29.NextIndex;

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label28; }

            // NOT 30
            int _start_i30 = _index;

            // ANY
            _ParseAny(ref _index);

            // NOT 30
            var _r30 = _results.Pop();
            _results.Push( _r30 == null ? new _Pantheon_Item(_start_i30, _input_enumerable) : null);
            _index = _start_i30;
        label28: // AND
            var _r28_2 = _results.Pop();
            var _r28_1 = _results.Pop();

            if (_r28_1 != null && _r28_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i28, _index, _input_enumerable, _r28_1.Results.Concat(_r28_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i28;
            }

        label3: // OR
            int _dummy_i3 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i2; } else goto label2;

            // AND 32
            int _start_i32 = _index;

            // CALL Multiply
            var _start_i33 = _index;
            _Pantheon_Item _r33;

            _r33 = _MemoCall("Multiply", _index, Multiply, new _Pantheon_Item[] { new _Pantheon_Item(FloatValue) });

            if (_r33 != null) _index = _r33.NextIndex;

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label32; }

            // NOT 34
            int _start_i34 = _index;

            // ANY
            _ParseAny(ref _index);

            // NOT 34
            var _r34 = _results.Pop();
            _results.Push( _r34 == null ? new _Pantheon_Item(_start_i34, _input_enumerable) : null);
            _index = _start_i34;
        label32: // AND
            var _r32_2 = _results.Pop();
            var _r32_1 = _results.Pop();

            if (_r32_1 != null && _r32_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i32, _index, _input_enumerable, _r32_1.Results.Concat(_r32_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i32;
            }

        label2: // OR
            int _dummy_i2 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i1; } else goto label1;

            // AND 36
            int _start_i36 = _index;

            // CALL Multiply
            var _start_i37 = _index;
            _Pantheon_Item _r37;

            _r37 = _MemoCall("Multiply", _index, Multiply, new _Pantheon_Item[] { new _Pantheon_Item(DoubleValue) });

            if (_r37 != null) _index = _r37.NextIndex;

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label36; }

            // NOT 38
            int _start_i38 = _index;

            // ANY
            _ParseAny(ref _index);

            // NOT 38
            var _r38 = _results.Pop();
            _results.Push( _r38 == null ? new _Pantheon_Item(_start_i38, _input_enumerable) : null);
            _index = _start_i38;
        label36: // AND
            var _r36_2 = _results.Pop();
            var _r36_1 = _results.Pop();

            if (_r36_1 != null && _r36_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i36, _index, _input_enumerable, _r36_1.Results.Concat(_r36_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i36;
            }

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // OR shortcut
            if (_results.Peek() == null) { _results.Pop(); _index = _start_i0; } else goto label0;

            // AND 40
            int _start_i40 = _index;

            // CALLORVAR Literal
            _Pantheon_Item _r41;

            _r41 = _MemoCall("Literal", _index, Literal, null);

            if (_r41 != null) _index = _r41.NextIndex;

            // AND shortcut
            if (_results.Peek() == null) { _results.Push(null); goto label40; }

            // NOT 42
            int _start_i42 = _index;

            // ANY
            _ParseAny(ref _index);

            // NOT 42
            var _r42 = _results.Pop();
            _results.Push( _r42 == null ? new _Pantheon_Item(_start_i42, _input_enumerable) : null);
            _index = _start_i42;
        label40: // AND
            var _r40_2 = _results.Pop();
            var _r40_1 = _results.Pop();

            if (_r40_1 != null && _r40_2 != null)
            {
                _results.Push( new _Pantheon_Item(_start_i40, _index, _input_enumerable, _r40_1.Results.Concat(_r40_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _results.Push(null);
                _index = _start_i40;
            }

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }

    } // class Pantheon

} // namespace Pantheon

