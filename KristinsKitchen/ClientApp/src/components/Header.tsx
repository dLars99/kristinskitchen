import React, { useState } from 'react'
import { makeStyles } from '@material-ui/core/styles'
import AppBar from '@material-ui/core/AppBar'
import Toolbar from '@material-ui/core/Toolbar'
import Typography from '@material-ui/core/Typography'
import IconButton from '@material-ui/core/IconButton'
import AccountCircle from '@material-ui/icons/AccountCircle'

const useStyles = makeStyles((theme) => ({
    root: {
        flexGrow: 1,
        height: "12vh",
    },
    menuButton: {
        marginRight: theme.spacing(2),
    },
    title: {
        flexGrow: 1,
    },
}));

const Header = () => {

    const classes = useStyles()
    const [menuAnchorEl, setMenuAnchorEl] = useState<HTMLButtonElement>()

    const handleMenu = (event: React.MouseEvent<HTMLButtonElement>): void => {
        setMenuAnchorEl(event.currentTarget)
    }

    return (
        <div className={classes.root}>
            <AppBar position="static" color="secondary">
                <Toolbar>
                    <Typography variant="h4" className={classes.title}>Kristin's Kitchen</Typography>
                    <div>
                        <IconButton
                            aria-label="account of current user"
                            aria-controls="menu-appbar"
                            aria-haspopup="true"
                            onClick={handleMenu}
                            color="inherit"
                            size={"medium"}
                        >
                            <AccountCircle style={{ fontSize: 50 }} />
                        </IconButton>
                    </div>
                </Toolbar>
            </AppBar>
        </div>
    )
}

export default Header