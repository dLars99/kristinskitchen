import React from 'react'
import TodaysMenu from './TodaysMenu'
import { homeImages } from '../assets/images'

import { makeStyles } from '@material-ui/core'
import Grid from '@material-ui/core/Grid'
import Typography from '@material-ui/core/Typography'
import IconButton from '@material-ui/core/IconButton'
import AddIcon from '@material-ui/icons/Add'

const useStyles = makeStyles((theme) => ({
    main: {
        width: "90%",
        margin: "20px auto",
    },
    homeButtonGrid: {
        marginTop: "3vh",
        height: "50vh",
    },
    firstRow: {
        height: "55%",
        display: "flex",
        justifyContent: "center",
    },
    secondRow: {
        height: "45%",
        display: "flex",
        justifyContent: "center",
    },
    homeButton: {
        width: "100%",
        height: "100%",
        borderRadius: "30px",
        backgroundSize: "cover",
        backgroundPosition: "center",
    },
    homeButtonOverlay: {
        width: "100%",
        height: "100%",
        padding: "1rem 2rem",
        borderRadius: "30px",
        backgroundColor: "rgba(0, 0, 0, 0.5)",
        color: "#fff",
        "&:hover": {
            backgroundColor: "rgba(0, 0, 0, 0.3)"
        },
        position: "relative",
    },
    addButton: {
        borderRadius: "50%",
        width: 50,
        height: 50,
        padding: 0,
        fontSize: "50px",
        backgroundImage: "linear-gradient(rgba(255, 215, 202, 0.87), rgba(158, 17, 17, 0.82))",
        position: "absolute",
        bottom: 15,
        right: 15,
    },
    addButtonIcon: {
        padding: 0,
        position: "absolute",
        left: 0,
        top: 0,
        verticalAlign: "top",
        color: "#000",
        "& svg": {
            fontSize: 50,
        }
    }
}))

const Home = () => {
    const classes = useStyles()

    return (
        <Grid container className={classes.main}>
            <Grid item xs={12}>
                <TodaysMenu />
            </Grid>
            <Grid container spacing={4} className={classes.homeButtonGrid}>
                <Grid item xs={6} className={classes.firstRow}>
                    <div className={classes.homeButton} style={{ backgroundImage: `url(${homeImages.pantry})` }}>
                        <div className={classes.homeButtonOverlay}>
                            <Typography variant={"h5"}>My Pantry</Typography>
                            <div className={classes.addButton}>
                                <IconButton className={classes.addButtonIcon}>
                                    <AddIcon />
                                </IconButton>
                            </div>
                        </div>
                    </div>
                </Grid>
                <Grid item xs={6} className={classes.firstRow}>
                    <div className={classes.homeButton} style={{ backgroundImage: `url(${homeImages.recipes})` }}>
                        <div className={classes.homeButtonOverlay}>
                            <Typography variant={"h5"}>Recipes</Typography>
                            <div className={classes.addButton}>
                                <IconButton className={classes.addButtonIcon}>
                                    <AddIcon />
                                </IconButton>
                            </div>
                        </div>
                    </div>
                </Grid>
                <Grid item xs={6} className={classes.secondRow}>
                    <div className={classes.homeButton} style={{ backgroundImage: `url(${homeImages.groceryList})` }}>
                        <div className={classes.homeButtonOverlay}>
                            <Typography variant={"h5"}>Grocery List</Typography>
                            <div className={classes.addButton}>
                                <IconButton className={classes.addButtonIcon}>
                                    <AddIcon />
                                </IconButton>
                            </div>
                        </div>
                    </div>
                </Grid>
                <Grid item xs={6} className={classes.secondRow}>
                    <div className={classes.homeButton} style={{ backgroundImage: `url(${homeImages.mealPlan})` }}>
                        <div className={classes.homeButtonOverlay}>
                            <Typography variant={"h5"}>Meal Plan</Typography>
                            <div className={classes.addButton}>
                                <IconButton className={classes.addButtonIcon}>
                                    <AddIcon />
                                </IconButton>
                            </div>
                        </div>
                    </div>
                </Grid>
            </Grid>
        </Grid >
    )
}

export default Home