import Button from '@mui/material/Button'
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import React from 'react'

export default function SignInMenu() {
  return (
    <Button variant="outlined" size='large' startIcon={<AccountCircleIcon />}>Sign In</Button>
  )
}
