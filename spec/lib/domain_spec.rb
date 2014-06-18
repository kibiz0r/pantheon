require "spec_helper"

describe Domain do
  class Foo
  end

  class MyDomain < Domain
    directive :emit_foo do
      emit Foo.new
    end
  end

  subject do
    MyDomain.new
  end

  describe "emitting objects" do
    it "causes a materialize event" do
      subject.emit_foo
    end
  end
end
