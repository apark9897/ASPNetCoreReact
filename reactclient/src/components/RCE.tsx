import { useState, FC, useEffect, useMemo } from 'react';
import {
  Box,
  IconButton,
  InputBase,
  Typography,
  Select,
  MenuItem,
  FormControl,
  useTheme,
  useMediaQuery,
  Icon,
  ToggleButtonGroup,
  Divider
} from '@mui/material';
import {
  FormatBoldSharp,
  FormatItalicSharp,
  StrikethroughSSharp,
  CodeSharp,
  FormatClearSharp,
  LooksOneSharp,
  LooksTwoSharp,
  Looks3Sharp,
  FormatListBulletedSharp,
  FormatListNumberedSharp,
  IntegrationInstructionsSharp,
  FormatQuoteSharp,
  HorizontalRuleSharp,
  HeightSharp,
  UndoSharp,
  RedoSharp
} from '@mui/icons-material';
import WidgetWrapper from 'components/WidgetWrapper';
import { EditorContent, useEditor } from '@tiptap/react'
import StarterKit from '@tiptap/starter-kit';
import Underline from '@tiptap/extension-underline';
import TextAlign from '@tiptap/extension-text-align';
import Link from '@tiptap/extension-link';
import { Editor } from '@tiptap/react/dist/packages/react/src/Editor'

const MenuBar: FC<{ editor: Editor | null }> = ({ editor }) => {
  if (!editor) {
    return null
  }

  return (
    <>
      <ToggleButtonGroup
        aria-label="text formatting"
      >
        <IconButton
          onClick={() => editor.chain().focus().toggleBold().run()}
          disabled={
            !editor.can()
              .chain()
              .focus()
              .toggleBold()
              .run()
          }
          className={editor.isActive('bold') ? 'is-active' : ''}>
          <FormatBoldSharp />
        </IconButton>
        <IconButton
          onClick={() => editor.chain().focus().toggleItalic().run()}
          disabled={
            !editor.can()
              .chain()
              .focus()
              .toggleItalic()
              .run()
          }
          className={editor.isActive('italic') ? 'is-active' : ''}>
          <FormatItalicSharp />
        </IconButton>
        <IconButton
          onClick={() => editor.chain().focus().toggleStrike().run()}
          disabled={
            !editor.can()
              .chain()
              .focus()
              .toggleStrike()
              .run()
          }
          className={editor.isActive('strike') ? 'is-active' : ''}
        >
          <StrikethroughSSharp />
        </IconButton>
        <IconButton
          onClick={() => editor.chain().focus().toggleCode().run()}
          disabled={
            !editor.can()
              .chain()
              .focus()
              .toggleCode()
              .run()
          }
          className={editor.isActive('code') ? 'is-active' : ''}
        >
          <CodeSharp />
        </IconButton>
        <IconButton onClick={() => editor.chain().focus().unsetAllMarks().clearNodes().run()}>
          <FormatClearSharp />
        </IconButton>
        <IconButton
          onClick={() => editor.chain().focus().toggleHeading({ level: 2 }).run()}
          className={editor.isActive('heading', { level: 2 }) ? 'is-active' : ''}
        >
          <LooksOneSharp />
        </IconButton>
        <IconButton
          onClick={() => editor.chain().focus().toggleHeading({ level: 3 }).run()}
          className={editor.isActive('heading', { level: 3 }) ? 'is-active' : ''}
        >
          <LooksTwoSharp />
        </IconButton>
        <IconButton
          onClick={() => editor.chain().focus().toggleHeading({ level: 4 }).run()}
          className={editor.isActive('heading', { level: 4 }) ? 'is-active' : ''}
        >
          <Looks3Sharp />
        </IconButton>
        <IconButton
          onClick={() => editor.chain().focus().toggleBulletList().run()}
          className={editor.isActive('bulletList') ? 'is-active' : ''}
        >
          <FormatListBulletedSharp />
        </IconButton>
        <IconButton
          onClick={() => editor.chain().focus().toggleOrderedList().run()}
          className={editor.isActive('orderedList') ? 'is-active' : ''}
        >
          <FormatListNumberedSharp />
        </IconButton>
        <IconButton
          onClick={() => editor.chain().focus().toggleCodeBlock().run()}
          className={editor.isActive('codeBlock') ? 'is-active' : ''}
        >
          <IntegrationInstructionsSharp />
        </IconButton>
        <IconButton
          onClick={() => editor.chain().focus().toggleBlockquote().run()}
          className={editor.isActive('blockquote') ? 'is-active' : ''}
        >
          <FormatQuoteSharp />
        </IconButton>
        <IconButton onClick={() => editor.chain().focus().setHorizontalRule().run()}>
          <HorizontalRuleSharp />
        </IconButton>
        <IconButton onClick={() => editor.chain().focus().setHardBreak().run()}>
          <HeightSharp />
        </IconButton>
        <IconButton
          onClick={() => editor.chain().focus().undo().run()}
          disabled={
            !editor.can()
              .chain()
              .focus()
              .undo()
              .run()
          }
        >
          <UndoSharp />
        </IconButton>
        <IconButton
          onClick={() => editor.chain().focus().redo().run()}
          disabled={
            !editor.can()
              .chain()
              .focus()
              .redo()
              .run()
          }
        >
          <RedoSharp />
        </IconButton>
      </ToggleButtonGroup>
    </>
  )
}

const RCE: FC<{ handleSubmit: (a: any) => void }> = ({ handleSubmit }) => {
  const theme = useTheme();
  const light = theme.palette.neutral.light;
  const editor = useEditor({
    extensions: [
      StarterKit.configure({
        bulletList: {},
        orderedList: {},
      }),
      Underline,
      Link,
      TextAlign.configure({ types: ['heading', 'paragraph'] })
    ],
    content: `What are your thoughts?`,
  })

  return (
    <WidgetWrapper>
      <Box sx={{ border: 1, borderColor: light, borderRadius: "0.5rem" }}>
        <Box margin="0.25rem">
          <MenuBar editor={editor} />
        </Box>
        <Box paddingX="1rem" sx={{ borderTop: 1, borderColor: light }}>
          <EditorContent editor={editor} />
        </Box>
      </Box>
    </WidgetWrapper>
  )
}

export default RCE;
