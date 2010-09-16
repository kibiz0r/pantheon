macro testfixture(name as ReferenceExpression):
    klass = [|
        [TestFixture]
        public class $(name):
            pass
    |]
    yield klass