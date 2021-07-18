import React from 'react'

import { makeStyles } from '@material-ui/core'
import Grid, { GridSize } from '@material-ui/core/Grid'
import Typography from '@material-ui/core/Typography'
import Tapsilog from "../assets/images/tapsilog.jpg"
import Meatloaf from "../assets/images/meatloaf.jpg"

const useStyles = makeStyles((theme) => ({
    menu: {
        width: "80%",
        margin: "0 auto",
        borderRadius: "30px",
        backgroundColor: "rgba(147, 116, 138, 0.25)",
        height: "20vh",
        padding: ".6rem 2rem .6rem",
        color: "#fff"
    },
    menuItemFrame: {
        height: "100%",
        display: "flex",
        marginTop: ".3rem",
        justifyContent: "center",
    },
    menuItem: {
        backgroundSize: "cover",
        width: "80%",
        height: "100%",
        borderRadius: "10px",
    },
    menuItemOverlay: {
        width: "100%",
        height: "100%",
        padding: ".3rem 1rem 0",
        borderRadius: "10px",
        backgroundColor: "rgba(0, 0, 0, 0.4)",
        color: "#fff",
        "&:hover": {
            backgroundColor: "rgba(0, 0, 0, 0.2)"
        },
        position: "relative",
    },
}))

const TodaysMenu = () => {

    const classes = useStyles()
    const menuListings = [
        {
            recipe: {
                description: "Tapsilog",
            },
            image: Tapsilog,
        },
        {
            recipe: {
                description: "Meatloaf",
            },
            image: Meatloaf,
        }
    ]

    return (
        <div className={classes.menu}>
            <Typography variant="h6">Today's Menu</Typography>
            <Grid container justify="space-evenly" style={{ height: "65%", marginTop: ".1rem" }}>
                {menuListings.length > 0 && menuListings.map(meal => (
                    <Grid item xs={12 / (menuListings.length || 1) as GridSize} className={classes.menuItemFrame}>
                        <div className={classes.menuItem} style={{ backgroundImage: `url(${meal.image})` }}>
                            <div className={classes.menuItemOverlay}>
                                <Typography>{meal.recipe.description}</Typography>
                            </div>
                        </div>
                    </Grid>
                ))}
            </Grid>
        </div>
    )
}

export default TodaysMenu