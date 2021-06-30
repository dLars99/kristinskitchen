import React from 'react'

import { makeStyles } from '@material-ui/core'
import Grid, { GridSize } from '@material-ui/core/Grid'
import Typography from '@material-ui/core/Typography'

const useStyles = makeStyles((theme) => ({
    menu: {
        width: "100%",
        borderRadius: "30px",
        backgroundColor: "rgba(147, 116, 138, 0.25)",
        height: "20vh"
    },
}))

const TodaysMenu = () => {

    const classes = useStyles()
    const menuListings = [
        {
            recipe: {
                description: "Tapsilog",
            }
        },
        {
            recipe: {
                description: "Meatloaf",
            }
        }
    ]

    return (
        <Grid container className={classes.menu}>
            <Grid item xs={12}>
                <Typography>Today's Menu</Typography>
            </Grid>
            {menuListings.length > 0 && menuListings.map(meal => (
                <Grid item xs={12 / (menuListings.length || 1) as GridSize}>
                    {meal.recipe.description}
                </Grid>
            ))}
        </Grid>
    )
}

export default TodaysMenu