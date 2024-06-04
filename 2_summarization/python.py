    def splitStringIntoSentences(str):
        if not str:
            return ["Null argument"]

        if not re.search(r'(?:^|[^.!?]+)[.!?]+\s?', str):
            str += str + "."

        sentences = re.findall(r'(?:^|[^.!?]+)[.!?]+\s?', str) or []

        result = []

        if len(sentences) > 1:
            for i in range(0, len(sentences), 3):
                result.append(' '.join(sentences[i:i + 3]))
        else:
            maxLength = 800
            words = sentences[0].split(' ')
            currentLine = ''

            for word in words:
                lengthWithWord = len(currentLine) + len(word)

                if lengthWithWord <= maxLength:
                    currentLine += ('' if len(currentLine) == 0 else ' ') + word
                else:
                    result.append(currentLine)
                    currentLine = word

            if len(currentLine) > 0:
                result.append(currentLine)

        return result