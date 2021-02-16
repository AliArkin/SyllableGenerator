# SyllableGenerator
Syllable Generator for Uyghur Language


##Using
    Generator gen = new Generator();
    var result = gen.Generate(SyllableType.CVC);
    txtResult.Text = string.Join(Environment.NewLine, result.ToArray<string>());
