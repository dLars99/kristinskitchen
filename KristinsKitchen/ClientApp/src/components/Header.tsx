import React from 'react'
import AppBar from '@material-ui/core/AppBar'
import Toolbar from '@material-ui/core/Toolbar'
import Typography from '@material-ui/core/Typography'
import IconButton from '@material-ui/core/IconButton'
import AccountCircle from '@material-ui/icons/AccountCircle'

const Header = () => {

    const handleMenu = (): void => {
        console.log("Hi")
    }

    return (
        <AppBar position="static">
            <Toolbar>
                <Typography>Kristin's Kitchen</Typography>
            </Toolbar>
            <div>
                <IconButton
                    aria-label="account of current user"
                    aria-controls="menu-appbar"
                    aria-haspopup="true"
                    onClick={handleMenu}
                    color="inherit"
                >
                    <AccountCircle />
                </IconButton>
            </div>
        </AppBar>
    )
}

export default Header